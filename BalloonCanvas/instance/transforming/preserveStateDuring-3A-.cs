preserveStateDuring: aBlock
	| state result |
	state _ BalloonState new.
	state transform: transform.
	state colorTransform: colorTransform.
	state aaLevel: self aaLevel.
	result _ aBlock value: self.
	transform _ state transform.
	colorTransform _ state colorTransform.
	self aaLevel: state aaLevel.
	^result