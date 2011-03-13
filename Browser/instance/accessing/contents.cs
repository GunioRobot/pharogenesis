contents
	"Depending on the current selection, different information is retrieved.
	Answer a string description of that information. This information is the
	method of the currently selected class and message."

	editSelection == #none ifTrue: [^''].
	editSelection == #editSystemCategories 
		ifTrue: [^systemOrganizer printString].
	editSelection == #newClass 
		ifTrue: [^Class template: self selectedSystemCategoryName].
	editSelection == #editClass 
		ifTrue: [^self selectedClassOrMetaClass definition].
	editSelection == #editComment 
		ifTrue: [^self selectedClassOrMetaClass commentTemplate].
	editSelection == #hierarchy 
		ifTrue: [^self selectedClassOrMetaClass printHierarchy].
	editSelection == #editMessageCategories 
		ifTrue: [^self classOrMetaClassOrganizer printString].
	editSelection == #newMessage ifTrue: [^self selectedClassOrMetaClass sourceCodeTemplate].
	editSelection == #editMessage ifTrue: [^self selectedMessage].
	self error: 'Browser internal error: unknown edit selection.'