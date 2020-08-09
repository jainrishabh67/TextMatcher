import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams, HttpHandler, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'text-matcher-component',
  templateUrl: './text-matcher.component.html'
})
export class TextMatcherComponent
{
  public textString = null;
  public subTextString = null;
  public httpClient: HttpClient;
  public baseUrl: string;
  public output: string = null;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    this.httpClient = http;
    this.baseUrl = baseUrl;
  }

  public calculateSubStringPosition()
  {
    const params = new HttpParams()
      .set('textString', this.textString)
      .set('subTextString', this.subTextString);

    let headers = new HttpHeaders();
    headers = headers.append('responseType', 'text');

    this.httpClient.get(this.baseUrl + 'textMatcher', { headers: headers, params: params, responseType:'text' })
      .subscribe((result:string) =>
      {
        this.output = result.toString();
      },
        error => console.error(error));
  }
}
