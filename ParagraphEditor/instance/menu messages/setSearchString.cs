setSearchString
	"Make the current selection, if any, be the current search string."
	self hasCaret ifTrue: [view flash. ^ self].
	self setSearch:  self selection string