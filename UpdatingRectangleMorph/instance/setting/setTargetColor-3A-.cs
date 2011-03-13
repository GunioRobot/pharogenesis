setTargetColor: aColor

	putSelector ifNotNil:
		[self color: aColor.
		contents _ aColor.
		target scriptPerformer perform: self putSelector withArguments: (Array with: aColor)]
