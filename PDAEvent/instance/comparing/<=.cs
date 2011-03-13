<= other

	date = other date ifFalse: [^ date < other date].
	time == nil ifTrue: [^ true].
	other time == nil ifTrue: [^ false].
	^ time <= other time