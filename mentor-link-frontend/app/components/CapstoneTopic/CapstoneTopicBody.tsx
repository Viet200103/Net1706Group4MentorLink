'use client';
import { CapstoneTopic } from "@/cores/models/CapstoneTopic";
import PdfViewer from "./PdfViewer";
import SenderInfo from "./SenderInfo";
import ResponseMessage from "./ResponseMessage";
type Props = { capstoneTopic: CapstoneTopic };

export default function CapstoneTopicBody({ capstoneTopic }: Props) {
    return (
        <div className="w-screen h-screen overflow-auto m-4">

            <PdfViewer url="/CP3.pdf" />
            <div className="mt-6">
                <SenderInfo
                    avatarUrl="/next.svg"
                    name="Mr. Nguyễn Văn A"
                    createAt={capstoneTopic.sendTime}
                />
            </div>
            <hr className="w-full h-0.5 bg-gray-300 my-6 border-none rounded-full" />
            <ResponseMessage avatarUrl="/next.svg" respondBy="Người phản hồi" responeTime={capstoneTopic.responseTime} responseMessage={capstoneTopic.responseMessage} />

        </div>
    );
}   