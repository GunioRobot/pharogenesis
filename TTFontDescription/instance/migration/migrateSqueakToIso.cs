migrateSqueakToIso
	| tempTable |
	tempTable _ glyphTable copy.
	128 to: 255 do:[:ascii |
		glyphTable
			at: ascii + 1
			put:(tempTable at:(Character value: ascii) isoToSqueak asciiValue + 1)]