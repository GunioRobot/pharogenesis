baseColor: aColor
	| cc |
	cc _ aColor isTransparent ifTrue:[nil] ifFalse:[aColor].
	baseColor = cc ifTrue:[^self].
	baseColor _ cc.
	self releaseCachedState.
	self color: cc.
