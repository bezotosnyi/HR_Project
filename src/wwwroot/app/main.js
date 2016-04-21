import angular from 'angular';
import router from 'angular-ui-router';
import translate from 'angular-translate';
import 'angular-validation/dist/angular-validation';
import 'angular-validation/dist/angular-validation-rule';

import 'foundation-apps/dist/js/foundation-apps.js';
import 'foundation-apps/dist/js/foundation-apps-templates.js';

import 'foundation-icons/foundation_icons_general/sass/general_foundicons.scss';
import 'foundation-icons/foundation_icons_social/sass/social_foundicons.scss';


import './main.scss';

import config from './botConfig';
import configValidation from './configValidation';

import LoggerProvider   from './services/LoggerProvider';
import HttpProvider     from './services/HttpProvider';

import CandidateService  from './services/candidateService';
import VacancyService    from './services/vacancyService';
import ValidationService from './services/validationService';
import UserService       from './services/userService';

import uiMask from 'angular-ui-mask';
import phoneFormatFilter from './filters/PhoneFormatFilter';

import 'angularjs-datepicker/src/js/angular-datepicker';
import 'angularjs-datepicker/src/css/angular-datepicker.css';

import DatePickerDirective from './directives/datepickerwrapper/DatepickerWrapperDirective';

import SettingsService from './services/SettingsService';

var dependencies = [
   router,
   translate,
   uiMask,
   'foundation',
   'validation',
   'validation.rule',
   '720kb.datepicker'];

angular
   .module('bot', dependencies)

   .provider('LoggerService', LoggerProvider)
   .provider('HttpService',   HttpProvider)

   .service('CandidateService',  CandidateService)
   .service('VacancyService',    VacancyService)
   .service('ValidationService', ValidationService)
   .service('UserService',       UserService)
   .service('SettingsService',   SettingsService)

   .filter('tel', phoneFormatFilter)

   .directive('date', DatePickerDirective.createInstance)

   .config(config)
   .config(configValidation);
