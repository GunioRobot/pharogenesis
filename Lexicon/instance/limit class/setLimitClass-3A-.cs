setLimitClass: aClass
	"Set aClass as the limit class for this browser"

	| currentClass currentSelector |
	currentClass _ self selectedClassOrMetaClass.
	currentSelector _ self selectedMessageName.

	self limitClass: aClass.
	categoryList _ nil.
	self categoryListIndex: 0.
	self changed: #categoryList.
	self changed: #methodList.
	self changed: #contents.
	self adjustWindowTitle.
	self hasSearchPane
		ifTrue:
			[self setMethodListFromSearchString].

	self maybeReselectClass: currentClass selector: currentSelector

	