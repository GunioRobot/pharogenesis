mouseDown: evt

	| aPoint index isUp soundChoices adjustment |
	upArrow ifNotNil: [((isUp _ upArrow containsPoint: (aPoint _ evt cursorPoint)) or:
			[downArrow containsPoint: aPoint]) ifTrue: [
		soundChoices _ #('silence').  "default, if no SampledSound class"
		Smalltalk at: #SampledSound ifPresent:
			[:sampledSound | soundChoices _ sampledSound soundNames].
		index _ soundChoices indexOf: literal.
		index > 0 ifTrue:
			[adjustment _ isUp ifTrue: [1] ifFalse: [-1].
			self literal: (soundChoices atWrap: (index + adjustment))].
		self playSoundNamed: literal].
		^ self].

	super mouseStillDown: evt.
