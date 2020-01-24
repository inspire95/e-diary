import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class BaseService {

    constructor(private http: HttpClient) { }

    async baseGetRequest<T>(actionUrl: string, urlParameter: string, header: any): Promise<T> {
        const response = await this.http.get<T>(actionUrl + urlParameter, { headers: header }).toPromise();
        return response;
    }

    async basePostRequest<T>(actionUrl: string, body: any, header: any): Promise<T> {
        const response = await this.http.post<T>(actionUrl, body, { headers: header }).toPromise();
        return response;
    }


    async basePutRequest<T>(actionUrl: string, body: any, header: any): Promise<T> {
        const response = await this.http.put<T>(actionUrl, body, { headers: header }).toPromise();
        return response;
    }

    async baseDeleteRequest<T>(actionUrl: string, urlParameter: string, header: any): Promise<T> {
        const response = await this.http.delete<T>(actionUrl + urlParameter, { headers: header }).toPromise();
        return response;
    }
}