initialSOSSetup

	mcuWidth _ (components detectMax: [:c | c widthInBlocks]) widthInBlocks.
	mcuHeight _ (components detectMax: [:c | c heightInBlocks]) heightInBlocks.
	components do:
		[:c |
		c mcuWidth: mcuWidth mcuHeight: mcuHeight dctSize: DCTSize].
	hACTable , hDCTable do: [:t | t ifNotNil: [t makeDerivedTables]].
	bitBuffer _ 0.
	bitsInBuffer _ 0.
	lookahead _ JPEGHuffmanTable lookahead.
