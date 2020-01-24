import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Router } from '@angular/router';
import { User } from 'src/app/models/User';
import { UsersService } from 'src/app/services/users.service';

@Component({
  selector: 'my-nav',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})

export class UsersComponent implements OnInit {

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: false}) sort: MatSort;


  usersList: MatTableDataSource<User>;
  users: Array<User>;
  displayedColumns: string[] = ['FirstName', 'LastName', 'actions'];

  constructor(private _router: Router,
    private usersService: UsersService,
    public dialog: MatDialog,) { }

  ngOnInit() {
    this.users = new Array<User>();
    this.usersList = new MatTableDataSource<User>();
    this.getUsersList();
  }

  private async getUsersList() {
    const usersResponse = await this.usersService.getAllUsers();
    if (!usersResponse.isSuccess) {}
    
    this.users = usersResponse.data.users;
    this.usersList = new MatTableDataSource<User>(this.users);
    this.usersList.paginator = this.paginator
  }
}
