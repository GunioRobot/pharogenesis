insertNewProjectActionFor: newProj

	| me |

	me _ CurrentProjectRefactoring currentProjectName.
	listOfPages withIndexDo: [ :each :index |
		each first = me ifTrue: [
			listOfPages add: {newProj name} afterIndex: index.
			^self switchToThread: threadName.
		].
	].
	listOfPages add: {newProj name} afterIndex: listOfPages size.
	^self switchToThread: threadName
		
