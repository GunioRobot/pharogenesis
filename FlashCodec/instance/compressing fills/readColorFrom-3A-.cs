readColorFrom: aStream
	| pv |
	pv := stream next asciiValue +
			(stream next asciiValue bitShift: 8) +
				(stream next asciiValue bitShift: 16) +
					(stream next asciiValue bitShift: 24).
	^Color colorFromPixelValue: pv depth: 32