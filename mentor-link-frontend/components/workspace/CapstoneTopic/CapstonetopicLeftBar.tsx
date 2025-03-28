import type { CapstoneTopic } from "@/cores/models/CapstoneTopic";

type Props = {
    topics: CapstoneTopic[];
    onSelectTopic: (topic: CapstoneTopic) => void;
    selectedTopic: CapstoneTopic | null;
};

const LeftSidebar = ({ topics, onSelectTopic, selectedTopic }: Props) => {
    return (
        <div className="w-64 h-full overflow-y-auto bg-gray-100 border-r border-gray-300 p-2">
            {topics.map((topic, index) => (
                <div
                    key={topic.id || index}
                    onClick={() => onSelectTopic(topic)}
                    className={`p-3 cursor-pointer rounded-md mb-2 ${selectedTopic?.id === topic.id
                        ? 'bg-blue-500 text-white'
                        : 'bg-white hover:bg-gray-200'
                        }`}
                >
                    {topic.title}
                </div>
            ))}
        </div>
    );
};

export default LeftSidebar;
