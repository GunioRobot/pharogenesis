resetBoard
	Collection initialize.  "randomize"
	selection _ nil.
	self submorphsDo:
		[:m |
		m disabled: false.
		m setSwitchState: false.
		m color: palette atRandom]