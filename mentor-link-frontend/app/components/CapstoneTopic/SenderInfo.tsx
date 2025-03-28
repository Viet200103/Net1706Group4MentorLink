'use client';
import Image from "next/image";

type Props = {
    avatarUrl: string;
    name: string;
    createAt: string;
};

const SenderInfo = ({ avatarUrl, name, createAt }: Props) => {
    const handleDownload = () => {
        const url = '/CP3.pdf'; // Đường dẫn file
        const link = document.createElement('a');
        link.href = url;
        link.download = 'CP3.pdf';
        link.click();
    };
    return (
        <div className="flex justify-between items-center p-4 border-b border-gray-200">
            {/* Thông tin người gửi */}
            <div className="flex items-center space-x-4">
                {/* Hình đại diện */}
                <div className="w-10 h-10 relative flex-shrink-0">
                    <Image
                        src={avatarUrl}
                        alt={name}
                        layout="fill"
                        objectFit="cover"
                        className="rounded-full"
                    />
                </div>

                <div>
                    <p className="font-semibold text-md">{name}</p>
                    <p className="text-gray-500 text-sm">{createAt.toLocaleString()}</p>
                </div>
            </div>

            {/* Nút tải xuống */}
            <button
                onClick={handleDownload}
                className="bg-blue-500 text-white px-4 py-2 rounded-md shadow hover:bg-blue-600 transition duration-300"
            >
                Tải xuống
            </button>
        </div>
    );
}
export default SenderInfo;
