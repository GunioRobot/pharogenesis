copyClass
	| originalName copysName class oldDefinition newDefinition |
	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	originalName _ self selectedClass name.
	copysName _ self request: 'Please type new class name' initialAnswer: originalName.
	copysName = '' ifTrue: [^ self].  " Cancel returns '' "
	copysName _ copysName asSymbol.
	copysName = originalName ifTrue: [^ self].
	(Smalltalk includesKey: copysName)
		ifTrue: [^ self error: copysName , ' already exists'].
	oldDefinition _ self selectedClass definition.
	newDefinition _ oldDefinition copyReplaceAll: '#' , originalName asString with: '#' , copysName asString.
	Cursor wait 
		showWhile: [class _ Compiler evaluate: newDefinition logged: true.
					class copyAllCategoriesFrom: (Smalltalk at: originalName).
					class class copyAllCategoriesFrom: (Smalltalk at: originalName) class].
	self classListIndex: 0.
	self changed: #classList