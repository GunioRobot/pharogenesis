widthOfString: aString from: firstIndex to: lastIndex
	
	^ (aString copyFrom: firstIndex to: lastIndex) inject: 0 into: [:s :t | s _ s + (self widthOf: t)].