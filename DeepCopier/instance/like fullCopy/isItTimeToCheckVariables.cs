isItTimeToCheckVariables

	| now isIt |
	NextVariableCheckTime ifNil: [
		NextVariableCheckTime _ Time totalSeconds.
		^ true].
	now _ Time totalSeconds.
	isIt _ NextVariableCheckTime < now.
	isIt ifTrue: ["update time for next check"
		NextVariableCheckTime _ now + self intervalForChecks].
	^isIt
