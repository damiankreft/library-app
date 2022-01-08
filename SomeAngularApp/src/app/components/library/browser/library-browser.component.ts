import { Component, OnInit } from '@angular/core';
import { GenericResourceDto } from 'src/app/Dto/generic-resource-dto';
import { LibraryService } from 'src/app/services/libraryService/library.service';

@Component({
  selector: 'app-accounts',
  templateUrl: './library-browser.component.html',
  styleUrls: ['./library-browser.component.scss']
})
export class LibraryBrowserComponent implements OnInit {

  selectedResource?: GenericResourceDto;
  public resources!: GenericResourceDto[];

  constructor(private libraryService: LibraryService) { }

  ngOnInit(): void {
    this.libraryService.getGenericResources()
      .subscribe((data: any) => { this.resources = data; console.log(data); });
  }

  lease(): void {
    this.libraryService.lease();
  }
}
