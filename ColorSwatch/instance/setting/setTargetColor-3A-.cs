setTargetColor: aColor
	"Set the target color as indicated"

	putSelector ifNotNil:
		[self color: aColor.
		contents _ aColor.
		target perform: self putSelector withArguments: (Array with: argument with: aColor)]
