initialSOSSetup

	mcuWidth _ (components detectMax: [:c | c widthInBlocks]) widthInBlocks.
	mcuHeight _ (components detectMax: [:c | c heightInBlocks]) heightInBlocks.
	components do:[:c |
		c mcuWidth: mcuWidth mcuHeight: mcuHeight dctSize: DCTSize].
	stream resetBitBuffer.