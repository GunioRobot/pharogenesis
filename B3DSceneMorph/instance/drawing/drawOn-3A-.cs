drawOn: aCanvas 
	(aCanvas form == Display and:[self accelerationEnabled and:[self isFlexed not]])
		ifTrue:[self drawAcceleratedOn: aCanvas]
		ifFalse:[self drawSimulatedOn: aCanvas].