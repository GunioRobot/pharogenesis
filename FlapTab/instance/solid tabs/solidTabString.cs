solidTabString
	^ (self isCurrentlySolid
		ifTrue: ['currently using solid tab']
		ifFalse: ['use solid tab']) translated