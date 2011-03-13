currentIndex

	| currentName |

	currentName _ Project current name.
	listOfPages withIndexDo: [ :each :index |
		(each first = currentName and: [preferredIndex = index]) ifTrue: [^currentIndex _ index]
	].
	listOfPages withIndexDo: [ :each :index |
		each first = currentName ifTrue: [^currentIndex _ index]
	].
	
	currentIndex isNil
		ifTrue: [^ 1].

	^ currentIndex min: listOfPages size
