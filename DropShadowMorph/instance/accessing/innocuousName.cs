innocuousName
	| actualMorph |
	^ (actualMorph _ self renderedMorph) == self
		ifTrue:	[super innocuousName]
		ifFalse:	[actualMorph innocuousName]