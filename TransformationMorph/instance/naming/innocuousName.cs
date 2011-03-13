innocuousName
	| r |
	^ (r _ self renderedMorph) == self
		ifTrue: [super innocuousName] ifFalse: [r innocuousName]