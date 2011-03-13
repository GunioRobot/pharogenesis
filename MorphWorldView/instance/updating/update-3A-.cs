update: symbol

	^ symbol == #newColor
		ifTrue: [self topView backgroundColor: model color dominantColor; uncacheBits; display]
		ifFalse: [super update: symbol].
