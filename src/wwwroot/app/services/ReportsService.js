import utils  from '../utils.js';
import {
   each
} from 'lodash';
const DATE_TYPE = ['startDate', 'endDate'];
const REPORT_URL = 'report';
let _HttpService;

export default class ReportsService {
   constructor(HttpService) {
      'ngInject';
      _HttpService   = HttpService;
   }

   getDataForUserReport(searchParameters) {
      searchParameters = this._convertToServerDates(searchParameters);
      let userReportUrl = 'usersReport';
      return _HttpService.get(`${REPORT_URL}/${userReportUrl}`, searchParameters)
         .then(this._convertFromServerDates);
   }

   getDataForVacancyReport(searchParameters) {
      searchParameters = this._convertToServerDates(searchParameters);
      let vacancyReportUrl = 'vacanciesReport';
      return _HttpService.get(`${REPORT_URL}/${vacancyReportUrl}`, searchParameters)
         .then(this._convertFromServerDates);
   }

   getDataForCandidatesReport(searchParameters) {
      searchParameters = this._convertToServerDates(searchParameters);
      let candidatesReportUrl = 'candidateProgressReport';
      return _HttpService.get(`${REPORT_URL}/${candidatesReportUrl}`, searchParameters);
   }

   _convertToServerDates(searchParameters) {
      each(DATE_TYPE, (type) => {
         if (searchParameters[type]) {
            searchParameters[type] = utils.formatDateToServer(searchParameters[type]);
         };
      });
      return searchParameters;
   }

   _convertFromServerDates(report) {
      each(DATE_TYPE, (type) => {
         if (report[type]) {
            report[type] = utils.formatDateFromServer(report[type]);
         };
      });
      return report;
   }
}
