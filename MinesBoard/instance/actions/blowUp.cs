blowUp
	owner timeDisplay stop.
	self submorphsDo:
		[:m |
		m isMine ifTrue:
				[m switchState: true.].
		].
	flashCount _ 2.
	gameOver _ true.