export interface Hero {
  id: string;
  name: string;
  ability: string;
  firstTraining: Date;
  suitColor: string;
  startingPower: number;
  curetPower: number;
  trainedTodayTimes: number;
}
export interface HeroCreate {
  name: string;
  suitColor: string;
  power: number;
  ability: string;
}
