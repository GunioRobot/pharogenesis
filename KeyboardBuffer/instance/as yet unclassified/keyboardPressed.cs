keyboardPressed

	| evt |
	eventUsed ifFalse: [^ true].
	(evt _ event hand checkForMoreKeyboard) ifNil: [^ false].
	event _ evt.
	eventUsed _ false.
	^ true