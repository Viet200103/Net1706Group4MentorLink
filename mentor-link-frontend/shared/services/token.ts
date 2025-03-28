import 'server-only'

import {cookies} from "next/headers";
import {ACCESS_TOKEN} from "@/shared/constants/api";

export async function fetchWithToken(
    request: Request,
    input: string | URL | globalThis.Request,
    init?: RequestInit,
) {
    const authHeader = getTokenHeader()

    if (authHeader === null) {
        return new Response("No token provided", {status: 401});
    }

    console.log("Init argument ", init)

    const options: RequestInit = {
        ...init,
        headers: authHeader,
    };

    console.log("Init argument auth header", options)

    return await fetch(input, options)
}

export declare type Token =  string | null

export function getTokenFromCookie(): Token {
    let token: Token = null;
    cookies().then(reqCookie => {
        token = reqCookie.get(ACCESS_TOKEN)?.value || null
    });
    console.log("get-token-from-cookie", token)
    return token;
}

export function getTokenHeader() {
    const token: Token = getTokenFromCookie();
    return createTokenHeader(token);
}

export function createTokenHeader(token: Token) {
    if (token == null) {
        return null
    }

    const headers: Headers = new Headers({
        "Authorization": `Bearer ${token}`
    });

    return headers
}