textColor: textColor
	ignoreColorChanges ifTrue: [^ self].
	foregroundColor _ textColor