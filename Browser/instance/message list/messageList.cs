messageList
	"Answer an Array of the message selectors of the currently selected message category, provided that the messageCategoryListIndex is in proper range.  Otherwise, answer an empty Array  If messageCategoryListIndex is found to be larger than the number of categories (it happens!), it is reset to zero."
	| sel |
	(sel _ self messageCategoryListSelection) ifNil: [^ Array new].
	^ sel = ClassOrganizer allCategory
		ifTrue: 
			[self classOrMetaClassOrganizer
				ifNil:		[Array new]
				ifNotNil:	[self classOrMetaClassOrganizer allMethodSelectors]]
		ifFalse:
			[(self classOrMetaClassOrganizer listAtCategoryNumber: messageCategoryListIndex - 1)
				ifNil: [messageCategoryListIndex _ 0.  Array new]]