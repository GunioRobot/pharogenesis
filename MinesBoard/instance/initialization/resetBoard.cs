resetBoard

	gameStart _ false.
	gameOver _ false.
	[flashCount = 0] whileFalse: [self step].
	flashCount _ 0.
	tileCount _ 0.
	Collection initialize.  "randomize the Collection class"
	self purgeAllCommands.
	self submorphsDo: "set tiles to original state."
		[:m | m privateOwner: nil.  "Don't propagate all these changes..."
		m mineFlag: false.
		m disabled: false.
		m switchState: false.
		m isMine: false.
		m privateOwner: self].
	self changed  "Now note the change in bulk"