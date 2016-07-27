import template from './comments.directive.html';
import './comments.scss';
export default class CommentsDirective {
   constructor() {
      this.restrict   = 'E';
      this.template   = template;
      this.scope      = {
         type    : '@',
         comments: '=',
         save    : '=',
         remove  : '=',
         edit    : '='
      };
      this.controller = CommentsController;
   }
   static createInstance() {
      'ngInject';
      CommentsDirective.instance = new CommentsDirective();
      return CommentsDirective.instance;
   }
}

function CommentsController($scope, $translate) {
   'ngInject';
   const vm              = $scope;
   vm.typeWrap           = _getType();
   vm.currentComment     = {};
   vm.comments           = vm.comments || [];
   vm.addComment         = addComment;
   vm.editComment        = editComment;
   vm.removeComment      = removeComment;

   function addComment() {
      vm.save(vm.currentComment).then(() => {
         vm.currentComment   = {};
      });
   }

   function removeComment(comment) {
      comment.isForRemoved = true;
      vm.remove(comment).catch(() => comment.isForRemoved = false);
   }

   function editComment(comment) {
      vm.currentComment = comment;
      vm.edit(vm.currentComment);
   }

   function _getType() {
      if (vm.type === 'note') {
         return $translate.instant('COMMON.NOTES');
      } else {
         return $translate.instant('COMMON.COMMENTS');
      }
   }
}
