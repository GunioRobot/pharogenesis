display: aString at: aPoint from: minVal to: maxVal during: workBlock

	^self new
		initialContext: thisContext sender;
		display: aString at: aPoint from: minVal to: maxVal during: workBlock