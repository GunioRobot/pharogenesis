scrollByKeyboard
	| keyEvent |
	keyEvent _ sensor keyboardPeek.
	keyEvent ifNil: [^ false].
	(sensor controlKeyPressed or:[sensor commandKeyPressed]) ifFalse: [^ false].
	keyEvent asciiValue = 30
		ifTrue: 
			[sensor keyboard.
			self scrollViewDown ifTrue: [self moveMarker].
			^ true].
	keyEvent asciiValue = 31
		ifTrue: 
			[sensor keyboard.
			self scrollViewUp ifTrue: [self moveMarker].
			^ true].
	^ false