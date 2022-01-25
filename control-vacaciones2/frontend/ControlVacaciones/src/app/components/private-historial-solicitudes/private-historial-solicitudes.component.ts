import { Component, OnInit } from '@angular/core';
import { Solicitud } from 'src/app/models/solicitud';
import { SolicitudesService } from 'src/app/services/solicitudes.service';

@Component({
  selector: 'app-private-historial-solicitudes',
  templateUrl: './private-historial-solicitudes.component.html',
  styleUrls: ['./private-historial-solicitudes.component.css']
})
export class PrivateHistorialSolicitudesComponent implements OnInit {

  constructor(private api:SolicitudesService) { }

  solicitudes:Solicitud[];

  ngOnInit(): void {
    this.api.getSolicitudes(2).subscribe(data =>{
      this.solicitudes = data.slice().reverse();
    })
  }
}
