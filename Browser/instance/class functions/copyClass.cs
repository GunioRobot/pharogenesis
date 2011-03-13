copyClass
	| originalName copysName class oldDefinition newDefinition |
	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	originalName := self selectedClass name.
	copysName := self request: 'Please type new class name' initialAnswer: originalName.
	copysName = '' ifTrue: [^ self].  " Cancel returns '' "
	copysName := copysName asSymbol.
	copysName = originalName ifTrue: [^ self].
	(Smalltalk includesKey: copysName)
		ifTrue: [^ self error: copysName , ' already exists'].
	oldDefinition := self selectedClass definition.
	newDefinition := oldDefinition copyReplaceAll: '#' , originalName asString with: '#' , copysName asString.
	Cursor wait 
		showWhile: [class := Compiler evaluate: newDefinition logged: true.
					class copyAllCategoriesFrom: (Smalltalk at: originalName).
					class class copyAllCategoriesFrom: (Smalltalk at: originalName) class].
	self classListIndex: 0.
	self changed: #classList