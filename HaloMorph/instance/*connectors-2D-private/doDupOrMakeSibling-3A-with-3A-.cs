doDupOrMakeSibling: evt with: dupHandle
	"Ask hand to duplicate my target, if shift key *not* pressed, or make a sibling if shift key *is* pressed"

	^ evt shiftPressed
		ifTrue:
			[dupHandle color: Color green muchDarker.
			self doMakeSibling: evt with: dupHandle]
		ifFalse:
			[self doDup: evt with: dupHandle]