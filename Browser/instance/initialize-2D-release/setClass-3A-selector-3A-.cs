setClass: aBehavior selector: aSymbol
	"Set the state of a new, uninitialized Browser."

	| isMeta aClass systemCatIndex messageCatIndex |
	aBehavior ifNil: [^ self].
	(aBehavior isKindOf: Metaclass)
		ifTrue: [isMeta _ true. aClass _ aBehavior soleInstance]
		ifFalse: [isMeta _ false. aClass _ aBehavior].
	systemCatIndex _ SystemOrganization categories indexOf: aClass category.
	self systemCategoryListIndex: systemCatIndex.
	self classListIndex:
			((SystemOrganization listAtCategoryNumber: systemCatIndex)
					indexOf: aClass name).
	self metaClassIndicated: isMeta.
	aSymbol ifNil: [^ self].
	messageCatIndex _ aBehavior organization numberOfCategoryOfElement: aSymbol.
	self messageCategoryListIndex: messageCatIndex.
	messageCatIndex = 0 ifTrue: [^ self].
	self messageListIndex:
			((aBehavior organization listAtCategoryNumber: messageCatIndex)
					indexOf: aSymbol).
