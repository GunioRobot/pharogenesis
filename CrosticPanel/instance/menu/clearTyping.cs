clearTyping

	self isClean ifTrue: [^ self].
	(self confirm: 'Are you sure you want to discard all typing?') ifFalse: [^ self].
	super clearTyping.
	quotePanel clearTyping