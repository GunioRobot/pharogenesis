renameClass
	| oldName newName |
	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	oldName _ self selectedClass name.
	newName _ (self request: 'Please type new class name'
						initialAnswer: oldName) asSymbol.
	(newName isEmpty or:[newName = oldName]) ifTrue: [^ self].
	(self selectedPackage classes includesKey: newName)
		ifTrue: [^ self error: newName , ' already exists in the package'].
	systemOrganizer classify: newName under: self selectedSystemCategoryName.
	systemOrganizer removeElement: oldName.
	self selectedPackage renameClass: self selectedClass to: newName.
	self changed: #classList.
	self classListIndex: ((systemOrganizer listAtCategoryNamed: self selectedSystemCategoryName) indexOf: newName).
