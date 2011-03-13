addFirst: aLink 
	"Add aLink to the beginning of the receiver's list. Answer aLink."

	self isEmpty ifTrue: [lastLink := aLink].
	aLink nextLink: firstLink.
	firstLink := aLink.
	^aLink