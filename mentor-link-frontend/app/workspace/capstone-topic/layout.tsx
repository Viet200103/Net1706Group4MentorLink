
'use client';
import CapstoneTopicBody from "@/app/components/CapstoneTopic/CapstoneTopicBody";
import CapstoneTopicHeader from "@/app/components/CapstoneTopic/CapstoneTopicHeader";
import LeftSidebar from "@/app/components/CapstoneTopic/CapstonetopicLeftBar";

import { CapstoneTopic } from "@/cores/models/CapstoneTopic";
import { useEffect, useState } from "react";


export default function CapstoneTopicLayout({ children }: { children: React.ReactNode }) {

    return <div>
        {children}
    </div>
}