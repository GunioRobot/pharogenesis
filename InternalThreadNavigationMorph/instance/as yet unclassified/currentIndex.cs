currentIndex

	| currentName |

	currentName _ CurrentProjectRefactoring currentProjectName.
	listOfPages withIndexDo: [ :each :index |
		each first = currentName ifTrue: [^currentIndex _ index]
	].
	^currentIndex ifNil: [1]
