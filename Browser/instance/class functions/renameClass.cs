renameClass
	| oldName newName obs |
	classListIndex = 0
		ifTrue: [^ self].
	self okToChange
		ifFalse: [^ self].
	oldName _ self selectedClass name.
	newName _ self request: 'Please type new class name' initialAnswer: oldName.
	newName = ''
		ifTrue: [^ self].
	"Cancel returns ''"
	newName _ newName asSymbol.
	newName = oldName
		ifTrue: [^ self].
	(Smalltalk includesKey: newName)
		ifTrue: [^ self error: newName , ' already exists'].
	self selectedClass rename: newName.
	self changed: #classList.
	self
		classListIndex: ((systemOrganizer listAtCategoryNamed: self selectedSystemCategoryName)
				indexOf: newName).
	obs _ self systemNavigation
				allCallsOn: (Smalltalk associationAt: newName).
	obs isEmpty
		ifFalse: [self systemNavigation
				browseMessageList: obs
				name: 'Obsolete References to ' , oldName
				autoSelect: oldName]