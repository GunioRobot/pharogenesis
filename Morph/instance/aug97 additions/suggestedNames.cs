suggestedNames
	^ self isInWorld
		ifTrue:
			[self world suggestedNamesFor: self]
		ifFalse:
			[Array with: self innocuousName with: self innocuousName capitalized]