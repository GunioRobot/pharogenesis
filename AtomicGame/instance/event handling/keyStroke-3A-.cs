keyStroke: evt 
	| charValue |
	charValue _ evt keyCharacter asciiValue.
	"Tab pressed"
	(charValue = 9
			or: [charValue = 32])
		ifTrue: [self select: self nextMolecule].
	"This keys requires something selected"
	selected
		ifNotNil: ["Left pressed"
			charValue = 28
				ifTrue: [self makeMovement: -1 @ 0].
			"Right pressed"
			charValue = 29
				ifTrue: [self makeMovement: 1 @ 0].
			"Up pressed"
			charValue = 30
				ifTrue: [self makeMovement: 0 @ -1].
			"Down pressed"
			charValue = 31
				ifTrue: [self makeMovement: 0 @ 1]].
