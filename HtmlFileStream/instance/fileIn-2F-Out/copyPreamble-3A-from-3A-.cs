copyPreamble: preamble from: aStream
	"Make method category preambles bold at category changes."

	prevPreamble = preamble
		ifTrue: [super copyPreamble: preamble from: aStream]
		ifFalse: [self command: 'H3'.
				super copyPreamble: preamble from: aStream.
				self command: '/H3'.
				prevPreamble _ preamble]