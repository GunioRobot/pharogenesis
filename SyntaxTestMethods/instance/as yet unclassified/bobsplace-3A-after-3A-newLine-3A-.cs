bobsplace: letter after: before newLine: isNewLine 
	"Position this letter. Put its left edge where the previous letter's right 	edge is. Move down to the next line if isNewLine is true. Add some 	leading for condensed or expanded text."

	before isNil
		ifTrue: [self selfWrittenAsIll march: letter to: leftMargin topRight]
		ifFalse: 
			[isNewLine 
				ifTrue: 
					[self selfWrittenAsIll march: letter
						to: leftMargin right @ (before bottom + 1)]
				ifFalse: [self selfWrittenAsIll march: letter to: before topRight]].
	^self