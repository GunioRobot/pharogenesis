registerFills: fills

	| fillIndexList index fillIndex |
	((colorTransform notNil and:[colorTransform isAlphaTransform]) or:[
		fills anySatisfy: [:any| any notNil and:[any isTranslucent]]])
			ifTrue:[	self flush.
					self reset.
					postFlushNeeded _ true].
	fillIndexList _ WordArray new: fills size.
	index _ 1.
	[index <= fills size] whileTrue:[
		fillIndex _ self registerFill: (fills at: index).
		fillIndex == nil 
			ifTrue:[index _ 1] "Need to start over"
			ifFalse:[fillIndexList at: index put: fillIndex.
					index _ index+1]
	].
	^fillIndexList