fullCopy
	| copy |
	self mouseEnter: nil.		 "Make sure scrollBar is in morphic structure"
	copy _ super fullCopy.		"So that references are updated properly"
		"Will fail of any Players with scripts are in the ScrollPane"
	self mouseLeave: nil.
	^ copy mouseLeave: nil
