'use client';

import { useEffect, useState, useMemo } from "react";
import CapstoneTopicHeader from "@/app/components/CapstoneTopic/CapstoneTopicHeader";
import type { CapstoneTopic } from "@/cores/models/CapstoneTopic";
import LeftSidebar from "@/app/components/CapstoneTopic/CapstonetopicLeftBar";
import CapstoneTopicBody from "@/app/components/CapstoneTopic/CapstoneTopicBody";

export default function CapstoneTopic() {
    const [capstoneTopics, setCapstoneTopics] = useState<CapstoneTopic[]>([]);
    const [selectedTopic, setSelectedTopic] = useState<CapstoneTopic | null>(null);
    const [error, setError] = useState("");

    // 🟢 Fetch data từ API khi component được mount
    useEffect(() => {
        async function fetchCapstoneTopics() {
            try {
                const response = await fetch("https://localhost:7058/api/CapstoneTopics", {
                    method: 'GET',
                    headers: {
                        'Content-Type': 'application/json',
                    },
                });
                if (!response.ok) {
                    throw new Error("Network response was not ok");
                }
                const data = await response.json();
                setCapstoneTopics(data.result);
                if (data.result.length > 0) {
                    setSelectedTopic(data.result[0]); // Chọn topic đầu tiên mặc định
                }
            } catch (err) {
                if (err instanceof Error) {
                    setError(`Failed to fetch topics: ${err.message}`);
                }
            }
        }

        fetchCapstoneTopics();
    }, []);


    const handleSelectTopic = (topic: CapstoneTopic) => {
        setSelectedTopic(topic);
    };

    // 🟢 Dùng `useMemo` để tránh re-render không cần thiết
    const memoizedTopic = useMemo(() => selectedTopic, [selectedTopic]);

    if (error) {
        return <div className="text-red-500 p-4">{error}</div>;
    }

    return (
        <div className="flex h-screen overflow-hidden">
            {/* Left Sidebar */}
            <div className="w-64 overflow-y-auto border-r border-gray-300">
                <LeftSidebar
                    topics={capstoneTopics}
                    onSelectTopic={handleSelectTopic}
                    selectedTopic={memoizedTopic}
                />
            </div>

            {/* Main Content */}
            <div className="flex-1 overflow-y-auto p-4">
                {memoizedTopic ? (
                    <div key={memoizedTopic.id} className="max-w-4xl mx-auto">
                        <CapstoneTopicHeader capstoneTopic={memoizedTopic} />
                        <CapstoneTopicBody capstoneTopic={memoizedTopic} />
                    </div>
                ) : (
                    <div className="text-gray-500">Chưa có topic nào được chọn.</div>
                )}
            </div>
        </div>
    );

}
