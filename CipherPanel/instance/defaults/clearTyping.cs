clearTyping
	self isClean
		ifTrue: [^ self].
	(self confirm: 'Are you sure you want to discard all typing?' translated)
		ifFalse: [^ self].
	super clearTyping