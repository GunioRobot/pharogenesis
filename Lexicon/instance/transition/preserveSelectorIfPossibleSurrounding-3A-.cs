preserveSelectorIfPossibleSurrounding: aBlock
	"Make a note of the currently-selected method; perform aBlock and then attempt to reestablish that same method as the selected one in the new circumstances"

	| aClass aSelector |
	aClass _ self selectedClassOrMetaClass.
	aSelector _ self selectedMessageName.
	aBlock value.
	
	self hasSearchPane
		ifTrue:
			[self setMethodListFromSearchString]
		ifFalse:
			[self maybeReselectClass: aClass selector: aSelector]