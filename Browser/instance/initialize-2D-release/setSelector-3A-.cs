setSelector: aSymbol
	"Make the receiver point at the given selector, in the currently chosen class"

	| aClass messageCatIndex |
	aSymbol ifNil: [^ self].
	(aClass _ self selectedClassOrMetaClass) ifNil: [^ self].
	messageCatIndex _ aClass organization numberOfCategoryOfElement: aSymbol.
	self messageCategoryListIndex: messageCatIndex + 1.
	messageCatIndex = 0 ifTrue: [^ self].
	self messageListIndex:
			((aClass organization listAtCategoryNumber: messageCatIndex)
					indexOf: aSymbol)