setClass: aBehavior selector: aSymbol
	"Set the state of a new, uninitialized Browser."

	| isMeta aClass messageCatIndex |
	aBehavior ifNil: [^ self].
	(aBehavior isKindOf: Metaclass)
		ifTrue: [
			isMeta _ true.
			aClass _ aBehavior soleInstance]
		ifFalse: [
			isMeta _ false.
			aClass _ aBehavior].
	self selectCategoryForClass: aClass.
	self classListIndex: (
		(SystemOrganization listAtCategoryNamed: self selectedSystemCategoryName)
			indexOf: aClass name).
	self metaClassIndicated: isMeta.
	aSymbol ifNil: [^ self].
	messageCatIndex _ aBehavior organization numberOfCategoryOfElement: aSymbol.
	self messageCategoryListIndex: (messageCatIndex > 0
		ifTrue: [messageCatIndex + 1]
		ifFalse: [0]).
	messageCatIndex = 0 ifTrue: [^ self].
	self messageListIndex: (
		(aBehavior organization listAtCategoryNumber: messageCatIndex)
			indexOf: aSymbol).