areasRemainingToFill: aRectangle
	"Optimised like BorderedMorph."
	
	self fillStyle isTranslucent
		ifTrue: [^ Array with: aRectangle].
	self wantsRoundedCorners
		ifTrue: [(self borderWidth > 0
					and: [self borderColor isColor
							and: [self borderColor isTranslucent]])
				ifTrue: [^ aRectangle
						areasOutside: (self innerBounds intersect: self boundsWithinCorners)]
				ifFalse: [^ aRectangle areasOutside: self boundsWithinCorners]]
		ifFalse: [(self borderWidth > 0
					and: [self borderColor isColor
							and: [self borderColor isTranslucent]])
				ifTrue: [^ aRectangle areasOutside: self innerBounds]
				ifFalse: [^ aRectangle areasOutside: self bounds]]