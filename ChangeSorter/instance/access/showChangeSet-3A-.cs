showChangeSet: chgSet

	myChangeSet == chgSet ifFalse: [
		myChangeSet _ chgSet.
		currentClassName _ nil.
		currentSelector _ nil].
	self changed: #relabel.
	self changed: #mainButtonName.
	self changed: #classList.
	self changed: #messageList.
	self setContents.
	self changed: #contents.