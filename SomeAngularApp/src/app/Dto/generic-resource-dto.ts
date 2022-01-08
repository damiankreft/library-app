import { EditionDto } from "./edition-dto";

export class GenericResourceDto {
    public id!: number;
    public resourceType!: number;
    public genericResourceName!: string;
    public editions!: Array<EditionDto>;
    public authors!: any;
}