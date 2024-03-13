import { ProgrammeGroup } from "./programme-group.type"

export type Programme = {
    id: number,
    name: string,
    language: string,
    programme_group: ProgrammeGroup
}