import {ElementType} from "react";

export default function WorkspaceSideBarItem({icon, name, link} : {
    icon: ElementType | null,
    name: string,
    link: string,
}) {
    const Icon = icon
    return (
        <li>
            <a href={link} className={"flex items-center text-sm font-semibold text-gray-500 px-4 py-2 rounded-lg hover:bg-gray-100 group"}>
                {Icon && <Icon className="w-4 h-4 text-gray-500 transition duration-75" />}
                <span className={"ms-3"}>{name}</span>
            </a>
        </li>
    )
}