controlActivity
	self scrollByKeyboard ifTrue: [^self].
	self processKeyboard.
	super controlActivity.
