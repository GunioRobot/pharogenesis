resetBoard
	Collection initialize.  "randomize"
	selection _ nil.
	self purgeAllCommands.
	self submorphsDo:
		[:m |
		m disabled: false.
		m setSwitchState: false.
		m color: palette atRandom].

