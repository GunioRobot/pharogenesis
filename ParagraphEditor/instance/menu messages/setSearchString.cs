setSearchString
	"Make the current selection, if any, be the current search string."
	startBlock = stopBlock ifTrue: [view flash. ^ self].
	self setSearch:  self selection string