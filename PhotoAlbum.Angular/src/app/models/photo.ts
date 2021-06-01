export interface Photo {
    id: number;
    fileName: string;
    description: string;
    date: Date;
    rate: number;
    data: File;
    isDeleted: boolean;
}
