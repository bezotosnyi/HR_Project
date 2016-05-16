import angular    from 'angular';
import router     from 'angular-ui-router';
import translate  from 'angular-translate';

import 'angular-validation/dist/angular-validation';
import 'angular-validation/dist/angular-validation-rule';

import 'angular-file-upload/dist/angular-file-upload';
import pagination from 'angular-utils-pagination';

import 'foundation-apps/dist/js/foundation-apps';
import 'foundation-apps/dist/js/foundation-apps-templates';

import 'foundation-icons/foundation_icons_general/sass/general_foundicons.scss';
import 'foundation-icons/foundation_icons_social/sass/social_foundicons.scss';
import 'foundation-icon-fonts/foundation-icons.css';
import 'oi.select/dist/select.min';
import 'oi.select/dist/select-tpls.min';
import 'oi.select/dist/select.min.css';

import './ta';
import './main.scss';

import config from './bot-config';
import configValidation from './config-validation';

import LoggerProvider   from './services/LoggerProvider';
import HttpProvider     from './services/HttpProvider';
import ValidationProvider  from './services/ValidationProvider';

import CandidateService  from './services/CandidateService';
import VacancyService    from './services/VacancyService';
import ThesaurusService  from './services/thesaurusService';
import UserService  from './services/UserService';

import ThesaurusDirective   from './directives/thesaurus/thesaurus';

import uiMask from 'angular-ui-mask';
import phoneFormatFilter from './filters/PhoneFormatFilter';

import DatePickerDirective from './directives/datepickerwrapper/DatePickerWrapperDirective';
import CanvasPreviewDirective from './directives/filePreview/CanvasPreview';

const dependencies = [
   router,
   translate,
   uiMask,
   'foundation',
   'validation',
   'validation.rule',
   '720kb.datepicker',
   'angularFileUpload',
   'textAngular',
   'oi.select',
   pagination
];

angular
   .module('bot', dependencies)

   .provider('LoggerService',     LoggerProvider)
   .provider('HttpService',       HttpProvider)
   .provider('ValidationService', ValidationProvider)

   .service('CandidateService',   CandidateService)
   .service('VacancyService',     VacancyService)
   .service('ThesaurusService',   ThesaurusService)
   .service('UserService',        UserService)

   .directive('thesaurus', ThesaurusDirective.createInstance)

   .filter('tel', phoneFormatFilter)

   .directive('date', DatePickerDirective.createInstance)
   .directive('ngThumb', CanvasPreviewDirective)

   .config(config)
   .config(configValidation);

angular.bootstrap(document.body, [ 'bot' ]);
