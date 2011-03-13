step

	decoder ifNil: [ ^self ].
	decoder processIOOnForce: [ :rectangle | self forceToFront: rectangle ].