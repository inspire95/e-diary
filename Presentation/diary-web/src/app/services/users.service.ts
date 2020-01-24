import { Injectable } from '@angular/core';
import { User } from 'src/app/models/User'
import { BaseService } from './base.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UsersResponse } from '../models/response-models/UsersResponse';
import { UserResponse } from '../models/response-models/UserResponse ';
import { BaseResponse } from '../models/response-models/BaseResponse';
import { BooleanResponse } from '../models/response-models/BooleanResponse';

@Injectable({
  providedIn: 'root'
})

export class UsersService extends BaseService {

  private headers: HttpHeaders;

  constructor(http: HttpClient) {
    super(http);
    this.headers = new HttpHeaders();
    this.headers = this.headers.set('Content-Type', 'application/json');
    this.headers = this.headers.set('Accept', 'application/json');
  }

  async getAllUsers(): Promise<BaseResponse<UsersResponse>> {
    const response = await this.baseGetRequest<BaseResponse<UsersResponse>>('http://localhost:44374/api/Users/GetUsers', "", this.headers);
    return response;
  }

  async getUser(UserId: string): Promise<BaseResponse<UserResponse>> {
    const param = "?UserId=" + UserId;
    const response = await this.baseGetRequest<BaseResponse<UserResponse>>('http://localhost:44374/api/Users/GetUserDetails', param, this.headers);
    return response;
  }

  async createUser(user: User): Promise<BaseResponse<UserResponse>> {
    const response = await this.basePostRequest<BaseResponse<UserResponse>>('http://localhost:44374/api/Users/CreateUsers', JSON.stringify(user), this.headers);
    return response;
  }

  async updateUser(user: User): Promise<BaseResponse<UserResponse>> {
    const response = await this.basePutRequest<BaseResponse<UserResponse>>('http://localhost:44374/api/Users/UpdateUser', JSON.stringify(user), this.headers);
    return response;
  }

  async deleteUser(UserId: string): Promise<BaseResponse<BooleanResponse>> {
    const param = "?UserId=" + UserId;
    const response = await this.baseDeleteRequest<BaseResponse<BooleanResponse>>('http://localhost:44374/api/Users/DeleteUser', param, this.headers);
    return response;
  }
}