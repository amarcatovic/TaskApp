import { User } from './User';

export class Task {
    id!: number;
    title!: string;
    description!: string;
    user!: User;
    assignee!: User;
    startDate!: Date;
    finishDate!: Date;
    isDone!: boolean;
}