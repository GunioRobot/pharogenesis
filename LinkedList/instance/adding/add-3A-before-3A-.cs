add: link before: otherLink

	| aLink |
	firstLink == otherLink ifTrue: [^ self addFirst: link].
	aLink _ firstLink.
	[aLink == nil] whileFalse: [
		aLink nextLink == otherLink ifTrue: [
			link nextLink: aLink nextLink.
			aLink nextLink: link.
			^ link
		].
		 aLink _ aLink nextLink.
	].
	^ self errorNotFound: otherLink