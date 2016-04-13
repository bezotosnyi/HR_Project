import angular from 'angular';
import router from 'angular-ui-router';
import translate from 'angular-translate';

import config from './botConfig';

import LoggerProvider   from './services/LoggerProvider';
import HttpProvider     from './services/HttpProvider';

import CandidateService from './services/candidateService';
import VacancyService   from './services/vacancyService';
import ThesaurusService   from './services/thesaurusService';

import ThesaurusDirective   from './directives/thesaurus/thesaurus';

var dependencies = [router, translate];

angular
   .module('bot', dependencies)

   .provider('LoggerService', LoggerProvider)
   .provider('HttpService',   HttpProvider)

   .service('CandidateService',  CandidateService)
   .service('VacancyService',    VacancyService)
   .service('ThesaurusService', ThesaurusService)

   .directive('thesaurus', ThesaurusDirective.createInstance)

   .config(config);
