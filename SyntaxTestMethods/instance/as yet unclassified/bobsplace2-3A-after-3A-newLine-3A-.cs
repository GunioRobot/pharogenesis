bobsplace2: letter after: before newLine: isNewLine 
	"Position this letter. Put its left edge where the previous letter's right edge is. Move down to the next line if isNewLine is true. Add some 	leading for condensed or expanded text."

	(self doFirstThatWorks)
		if: [before isNil]
			do: [self selfWrittenAsIll march: letter to: leftMargin topRight];
		if: [isNewLine]
			do: 
				[self selfWrittenAsIll march: letter
					to: leftMargin right @ (before bottom + 1)];
		if: [true] do: [self selfWrittenAsIll march: letter to: before topRight]