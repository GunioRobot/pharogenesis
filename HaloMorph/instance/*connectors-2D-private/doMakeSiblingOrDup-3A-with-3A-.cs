doMakeSiblingOrDup: evt with: dupHandle
	"Ask hand to duplicate my target, if shift key *is* pressed, or make a sibling if shift key *not* pressed"

	^ evt shiftPressed
		ifFalse:
			[self doMakeSibling: evt with: dupHandle]
		ifTrue:
			[dupHandle color: Color green.
			self doDup: evt with: dupHandle]