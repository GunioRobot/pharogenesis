controlActivity
	self scrollByKeyboard ifTrue: [^ self].
	self scrollBarContainsCursor
		ifTrue: [self scroll]
		ifFalse: [self normalActivity]