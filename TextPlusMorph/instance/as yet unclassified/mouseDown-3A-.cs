mouseDown: evt

	ignoreNextUp _ false.
	evt yellowButtonPressed ifTrue: [
		^self doYellowButtonPress: evt
	].
	^super mouseDown: evt
