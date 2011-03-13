add: link after: otherLink

	"Add otherLink  after link in the list. Answer aLink."

	| savedLink |
	lastLink == otherLink ifTrue: [^ self addLast: link].
	savedLink := otherLink nextLink.
	otherLink nextLink: link.
	link nextLink:  savedLink.
	^link.