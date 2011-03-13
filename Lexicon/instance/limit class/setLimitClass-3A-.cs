setLimitClass: aClass
	"Set aClass as the limit class for this browser"

	| currentClass currentSelector |
	currentClass := self selectedClassOrMetaClass.
	currentSelector := self selectedMessageName.

	self limitClass: aClass.
	categoryList := nil.
	self categoryListIndex: 0.
	self changed: #categoryList.
	self changed: #methodList.
	self changed: #contents.
	self adjustWindowTitle.
	self hasSearchPane
		ifTrue:
			[self setMethodListFromSearchString].

	self maybeReselectClass: currentClass selector: currentSelector

	