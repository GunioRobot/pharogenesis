innocuousName
	^ (self isFlap)
		ifTrue:
			['flap']
		ifFalse:
			[super innocuousName]