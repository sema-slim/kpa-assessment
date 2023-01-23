import { Component } from '@angular/core';
import { TasksService } from '../tasks.service';
import { Task } from '../task';

@Component({
  selector: 'app-tasks',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css'],
})
export class TasksComponent {
  constructor(private tasksService: TasksService) {}

  tasks: Task[] = [];

  ngOnInit(): void {
    console.log('getting tasks');
    this.getTasks();
  }

  getTasks(): void {
    this.tasksService.getTasks().subscribe((tasks) => {
      console.log(JSON.stringify(tasks));
      this.tasks = tasks;
    });
  }
}
