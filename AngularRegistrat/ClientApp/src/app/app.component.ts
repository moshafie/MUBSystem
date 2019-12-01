import { Component } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MUB System';

  private _hubConnection: HubConnection;
  private _toast: ToastrService;

  constructor(private toastr: ToastrService){
    this._toast = toastr;
  }

  ngOnInit(): void {
    this._hubConnection = new HubConnectionBuilder().withUrl("https://localhost:44390/api/PostModels/signalr/").build();
    this._hubConnection
      .start()
      .then(() => console.log('Connection started!'))
      .catch(err => console.log('Error while establishing connection :('));

    this._hubConnection.on("SendNotification", (id: string, message: string) => {
      this.toastr.show(message);
    });
  }
 
}
