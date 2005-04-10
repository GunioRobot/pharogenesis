displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta
	"Draw the given string from startIndex to stopIndex 
	at aPoint on the (already prepared) BitBlt."
	
	(aString isByteString) ifFalse: [^ self displayMultiString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: aPoint y + self ascent.].

	^ aBitBlt displayString: aString 
			from: startIndex 
			to: stopIndex 
			at: aPoint 
			strikeFont: self
			kern: kernDelta.