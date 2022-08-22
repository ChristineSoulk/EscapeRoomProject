export interface Room
{
    Id:number,
    Title:string,
    Description:string,
    Duration:number,
    Genre:number,
    Capacity:number,
    Difficulty:number,
    HasActor:boolean,
    Rating:number,
    EscapeRate:number,
    IsActive:boolean,
    StartingPricePerPerson:number,
    DiscountPerPerson:number,
    ImageUrl:string,
    VideoId:string
}


export interface IParticipants
{
    groupName:string;
    timesParticipated:number;
} 

export enum SortOptions
{
    titleisAsc = "titleisAsc",
    titleisDesc = "titleisDesc",
    groupisAsc = "groupisAsc",
    groupisDesc = "groupisDesc"
}