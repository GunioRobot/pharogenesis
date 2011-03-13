xUnderscore
	Preferences allowUnderscoreAssignment ifFalse:[^self xIllegal].
	self step.
	tokenType := #leftArrow.
	^token := #':='