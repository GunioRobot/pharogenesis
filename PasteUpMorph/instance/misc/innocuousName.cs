innocuousName
	^ (self hasProperty: #flap)
		ifTrue:
			['flap']
		ifFalse:
			[super innocuousName]