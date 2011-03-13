renameCategory
	"Prompt for a new category name and add it before the
	current selection, or at the end if no current selection"
	| oldIndex oldName newName |
	classListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	(oldIndex _ messageCategoryListIndex) = 0 ifTrue: [^ self].
	oldName _ self selectedMessageCategoryName.
	newName _ self
		request: 'Please type new category name'
		initialAnswer: oldName.
	newName isEmpty
		ifTrue: [^ self]
		ifFalse: [newName _ newName asSymbol].
	newName = oldName ifTrue: [^ self].
	self classOrMetaClassOrganizer
		renameCategory: oldName
		toBe: newName.
	Smalltalk changes reorganizeClass: self selectedClassOrMetaClass.
	self classListIndex: classListIndex.
	self messageCategoryListIndex: oldIndex