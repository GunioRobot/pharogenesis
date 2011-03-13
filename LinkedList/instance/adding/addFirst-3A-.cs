addFirst: aLink 
	"Add aLink to the beginning of the receiver's list. Answer aLink."

	self isEmpty ifTrue: [lastLink _ aLink].
	aLink nextLink: firstLink.
	firstLink _ aLink.
	^aLink