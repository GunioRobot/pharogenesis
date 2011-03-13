renameClass
	| oldName newName obs |
	classListIndex = 0
		ifTrue: [^ self].
	self okToChange
		ifFalse: [^ self].
	oldName := self selectedClass name.
	newName := self request: 'Please type new class name' initialAnswer: oldName.
	newName isEmptyOrNil
		ifTrue: [^ self].
	"Cancel returns ''"
	newName := newName asSymbol.
	newName = oldName
		ifTrue: [^ self].
	(Smalltalk includesKey: newName)
		ifTrue: [^ self error: newName , ' already exists'].
	self selectedClass rename: newName.
	self changed: #classList.
	self
		classListIndex: ((systemOrganizer listAtCategoryNamed: self selectedSystemCategoryName)
				indexOf: newName).
	obs := self systemNavigation
				allCallsOn: (Smalltalk associationAt: newName).
	obs isEmpty
		ifFalse: [self systemNavigation
				browseMessageList: obs
				name: 'Obsolete References to ' , oldName
				autoSelect: oldName]