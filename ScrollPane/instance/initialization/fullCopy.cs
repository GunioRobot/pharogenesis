fullCopy
	| copy |
	self mouseEnter.          "Make sure scrollBar is in morphic structure"
	copy _ super fullCopy.  "So that references are updated properly"
	self mouseLeave.
	^ copy mouseLeave