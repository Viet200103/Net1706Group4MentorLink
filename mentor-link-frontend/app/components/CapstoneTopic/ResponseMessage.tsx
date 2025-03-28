import Image from 'next/image';

type Props = {
    avatarUrl: string;
    respondBy: string;
    responeTime: string;
    responseMessage: string;
};

const ResponseMessage = ({ avatarUrl, respondBy, responeTime, responseMessage }: Props) => {
    return (
        <div className="flex items-start space-x-4 p-4 border-b border-gray-200">
            {/* Ảnh đại diện */}
            <div className="w-12 h-12 relative flex-shrink-0">
                <Image
                    src={avatarUrl}
                    alt={respondBy}
                    layout="fill"
                    objectFit="cover"
                    className="rounded-full"
                />
            </div>

            {/* Nội dung bình luận */}
            <div className="flex-1 overflow-hidden">
                {/* Tên và thời gian */}
                <div className="flex items-center space-x-2">
                    <p className="font-semibold text-gray-800">{respondBy}</p>
                    <span className="text-gray-500 text-sm">
                        {responeTime}
                    </span>
                </div>

                {/* Nội dung */}
                <p className="text-gray-700 mt-1 whitespace-pre-wrap break-words">
                    {responseMessage}
                </p>
            </div>
        </div>
    );
};

export default ResponseMessage;
