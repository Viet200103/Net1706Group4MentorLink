'use client';
import { CapstoneTopic } from "@/cores/models/CapstoneTopic";
import { useState } from "react";


type Props = {
    capstoneTopic: CapstoneTopic;
}

const CapstoneTopicHeader = ({ capstoneTopic }: Props) => {
    const [status, setStatus] = useState(capstoneTopic.status);

    const getStatus = (status: number) => {
        switch (status) {
            case 1:
                return 'Pending';
            case 2:
                return 'Accept';
            case 3:
                return 'Reject';
        }
    };
    const getStatusColor = (status: number) => {

        switch (status) {
            case 1:
                return 'bg-yellow-500';
            case 2:
                return 'bg-blue-500';
            case 3:
                return 'bg-red-500';
        }
    };
    return (
        <div className="flex items-center justify-between p-4 border-b border-gray-200 bg-gray-50 rounded-t-md">
            <div>
                <h1 className="text-xl font-bold text-gray-800">{capstoneTopic.title}</h1>
                <span className={`px-3 py-1 text-white text-sm rounded-md ${getStatusColor(status)}`}>{getStatus(status)}</span>
            </div>
            <div className="flex space-x-2">
                <button

                    className="bg-gray-500 text-white px-4 py-2 rounded-md shadow hover:bg-blue-600 transition duration-300"
                >
                    Approve
                </button>
                <button


                    className="bg-gray-500  text-white px-4 py-2 rounded-md shadow hover:bg-red-500 transition duration-300"
                >
                    Reject
                </button>
            </div>

        </div>
    );
}
export default CapstoneTopicHeader;

