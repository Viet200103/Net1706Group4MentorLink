import React from "react";

export default function WorkspaceLayout({children}: { children: React.ReactNode }) {
    return (
        <main>
            {children}
        </main>
    )
}