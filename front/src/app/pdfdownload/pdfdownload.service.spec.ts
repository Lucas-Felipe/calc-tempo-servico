import { TestBed } from '@angular/core/testing';

import { PdfdownloadService } from './pdfdownload.service';

describe('PdfdownloadService', () => {
  let service: PdfdownloadService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PdfdownloadService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
