<= other 
	date = other date ifFalse: [^date < other date].
	time isNil ifTrue: [^true].
	other time isNil ifTrue: [^false].
	^time <= other time