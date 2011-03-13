processVersionInfo: aVersionInfo
	| success |
	aVersionInfo = target ifTrue: [^ true].
	self pushLayer.
	success := (self knownAncestorsOf: aVersionInfo) anySatisfy:
				[:ea | self processVersionInfo: ea].
	self popLayer.
	success ifTrue: [self addToCurrentLayer: aVersionInfo].
	^ success	