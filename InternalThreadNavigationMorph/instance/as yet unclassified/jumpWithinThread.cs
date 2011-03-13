jumpWithinThread

	| aMenu me weHaveOthers |

	me _ CurrentProjectRefactoring currentProjectName.
	aMenu _ MenuMorph new defaultTarget: self.
	weHaveOthers _ false.
	listOfPages withIndexDo: [ :each :index |
		each first = me ifFalse: [
			weHaveOthers _ true.
			aMenu add: 'jump to <',each first,'>' selector: #jumpToIndex: argument: index.
		].
	].
	weHaveOthers ifFalse: [^self inform: 'This is the only project in this thread'].
	aMenu popUpEvent: self world primaryHand lastEvent in: self world