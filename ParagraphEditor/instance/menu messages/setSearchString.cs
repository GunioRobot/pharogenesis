setSearchString
	"Make the current selection, if any, be the current search string.  2/29/96 sw"

	startBlock = stopBlock ifTrue: [view flash. ^ self].
	self setSearch:  self selection string