areasRemainingToFill: aRectangle
	(color isColor and: [color isTranslucent]) ifTrue: [^ Array with: aRectangle].
	self wantsRoundedCorners
	ifTrue: [(borderWidth > 0 and: [borderColor isColor and: [borderColor isTranslucent]])
				ifTrue: [^ aRectangle areasOutside: (self innerBounds intersect: self boundsWithinCorners)]
				ifFalse: [^ aRectangle areasOutside: self boundsWithinCorners]]
	ifFalse: [(borderWidth > 0 and: [borderColor isColor and: [borderColor isTranslucent]])
				ifTrue: [^ aRectangle areasOutside: self innerBounds]
				ifFalse: [^ aRectangle areasOutside: self bounds]]