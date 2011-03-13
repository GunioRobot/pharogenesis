findClass
	"modified 4/29/96 sw so that if only 1 class matches the user-supplied string, or if the user-supplied string exactly matches a class name, then the pop-up menu is bypassed"
	| pattern foundClass classNames index reply |
	self controlTerminate.
	model okToChange ifFalse: [^ self classNotFound].
	pattern _ (reply _ FillInTheBlank request: 'Class Name?') asLowercase.
	pattern isEmpty ifTrue: [^ self classNotFound].
	(Smalltalk hasClassNamed: reply)
		ifTrue:
			[foundClass _ Smalltalk at: reply asSymbol]
		ifFalse:
 			[classNames _ Smalltalk classNames asArray select: 
				[:n | (n asLowercase indexOfSubCollection: pattern startingAt: 1) > 0].
			classNames isEmpty ifTrue: [^ self classNotFound].
			index _ classNames size == 1
				ifTrue:	[1]
				ifFalse:	[(PopUpMenu labelArray: classNames lines: #()) startUp].
			index = 0 ifTrue: [^ self classNotFound].
			foundClass _ Smalltalk at: (classNames at: index)].
 	model systemCategoryListIndex: (model systemCategoryList indexOf: foundClass category).
	model classListIndex: (model classList indexOf: foundClass name). 
	self controlInitialize