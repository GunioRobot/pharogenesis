otherPinFrom: aPin 
	^ pins first = aPin ifTrue: [pins second] ifFalse: [pins first]