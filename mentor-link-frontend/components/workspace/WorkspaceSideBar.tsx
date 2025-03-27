'use client'

import ViewKanbanIcon from '@mui/icons-material/ViewKanban';
import GroupIcon from '@mui/icons-material/Group';
import CalendarMonthIcon from '@mui/icons-material/CalendarMonth';
import ArticleIcon from '@mui/icons-material/Article';

import WorkspaceSideBarItem from "@/components/workspace/WorkspaceSideBarItem";

export default function WorkspaceSideBar() {

    return (
        <aside className={"fixed top-0 left-0 z-40 w-64 h-screen border-r-2 border-blue-200 transition-transform -translate-x-full sm:translate-x-0"}>
            <div className={"flex justify-between px-2 py-4 bg-transparent border-b-2 border-blue-200"}>
                <h5 className={"font-semibold"}>DTeam</h5>
            </div>
            <div className={"h-full px-2 py-4 overflow-y-auto bg-transparent"}>
                <ul >
                    <WorkspaceSideBarItem icon={CalendarMonthIcon} name={"Schedule"} link={"/workspace/schedule"} />
                    <WorkspaceSideBarItem icon={GroupIcon} name={"All members"} link={"/workspace/members"} />
                    <WorkspaceSideBarItem icon={ViewKanbanIcon} name={"All kanban boards"} link={"/workspace/kanban-boards"} />
                    <WorkspaceSideBarItem icon={ArticleIcon} name={"Capstone topic"} link={"/workspace/capstone-topic"} />
                </ul>

                <div className={"mt-2"}>
                    <div className={"flex border-t-2 border-blue-200"}>
                        <p className={"text-sm font-semibold px-2 py-2"}>Chat</p>
                    </div>
                </div>

            </div>
        </aside>
    )
}