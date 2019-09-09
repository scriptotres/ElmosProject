import employee from './employee';

export default class consultant {
  constructor(
    public id: any,
    public firstname: string,
    public lastname: string,
    public birthdate: any,

    public email: string,
    public workEmail: string,

    public telephone: number,
    public mobile: string,

    public addressid: any,
    public street: string,
    public number: string,
    public city: string,
    public zip: any,
    public country: string,

    public employeeId:any,
    public currentContract: {
      endDate: any,
      startDate: any,
      documentUrl: string,
      salary: number,
      signedDate: any,
      id: any,

    },
    public contracts: {
      endDate: any,
      startDate: any,
      documentUrl: string,
      salary: number,
      signedDate: any,
      id: any,
      contractTypeTitle:string

    }

  ) { }

}

