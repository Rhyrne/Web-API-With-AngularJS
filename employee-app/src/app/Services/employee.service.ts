import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Employee } from '../Models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiURL = 'https://localhost:7248/api/Employee'

  constructor() { }

  http = inject(HttpClient)

  getAllEmployees()
  {
    return this.http.get<Employee[]>(this.apiURL);
  }

  addEmployee(data:any)
  {
    return this.http.post(this.apiURL, data);
  }

  updateEmployee(employee: Employee)
  {
    return this.http.put(`${this.apiURL}/${employee.id}`, employee);
  }

  deleteEmployee(id: number)
  {
    return this.http.delete(`${this.apiURL}/${id}`);
  }
}
