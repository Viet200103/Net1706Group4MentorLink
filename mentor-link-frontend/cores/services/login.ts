'use server';

import {API_BASE_URL} from "@/shared/constants/api";
import {cookies} from "next/headers";
import {NextResponse} from "next/server";

interface LoginResponse {
    token: string;
}

export async function handleLogin({email, password} : {email: string, password: string}): Promise<NextResponse> {
    // Input validation
    if (!email || !password) {
        return NextResponse.json(
            { message: "Please fill in all fields" },
            { status: 400 }
        );
    }

    try {
        const response = await fetch(API_BASE_URL + '/auth/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({
                email: email,
                password: password,
            }),
        });

        const data = await response.json();

        // Handle different status codes
        if (!response.ok) {
            if (response.status === 401) {
                return NextResponse.json(
                    { message: data.message || "Invalid credentials" },
                    { status: 401 }
                );
            }
            return NextResponse.json(
                { message: data.message || "Login failed" },
                { status: response.status }
            );
        }

        // Type assertion for successful response
        const loginData = data as LoginResponse;
        const accessToken = loginData.token;

        // Set cookie
        cookies().then(cookie => {
            cookie.set({
                name: 'access_token',
                value: accessToken,
                httpOnly: true, // Makes cookie inaccessible to JavaScript (security)
                secure: process.env.NODE_ENV === 'production', // Only send over HTTPS in production
                path: '/', // Cookie available throughout the site
            });
        })


        return NextResponse.json(
            { message: 'Login successful' },
            { status: 200 }
        );
    } catch (error) {
        // Handle network errors or JSON parsing errors
        return NextResponse.json(
            { message: error instanceof Error ? error.message : "Internal server error" },
            { status: 500 }
        );
    }
}
