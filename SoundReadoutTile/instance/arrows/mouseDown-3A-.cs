mouseDown: evt
	"Handle a mouse down event"

	| aPoint index isUp soundChoices adjustment |
	upArrow ifNotNil: [((isUp _ upArrow containsPoint: (aPoint _ evt cursorPoint)) or:  [downArrow containsPoint: aPoint])
		ifTrue:
			[soundChoices _ self soundChoices.
			index _ soundChoices indexOf: literal ifAbsent: [1].
			index > 0 ifTrue:
				[adjustment _ isUp ifTrue: [1] ifFalse: [-1].
				self literal: (soundChoices atWrap: (index + adjustment))].
			self playSoundNamed: literal.
			^ self]].
	self soundNameFromUser ifNotNilDo:
		[:aSoundName |
			self literal: aSoundName.
			self playSoundNamed: literal]