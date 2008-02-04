displayString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY
	"Draw the given string from startIndex to stopIndex 
	at aPoint on the (already prepared) BitBlt."
	
	"Assume this is a wide string"
	| isMulti |
	isMulti := true.

	"Look for an excuse to use the fast primitive"
 	(aString isKindOf: ByteString) 
		ifTrue:[ isMulti := false]
		ifFalse:[ (aString isKindOf: Text) 
			ifTrue:[ (aString string isKindOf: ByteString) 
				ifTrue:[ isMulti := false ] 
	]].

	isMulti ifTrue:[^ self displayMultiString: aString on: aBitBlt from: startIndex to: stopIndex at: aPoint kern: kernDelta baselineY: baselineY].

	^ aBitBlt displayString: aString 
			from: startIndex 
			to: stopIndex 
			at: aPoint 
			strikeFont: self
			kern: kernDelta