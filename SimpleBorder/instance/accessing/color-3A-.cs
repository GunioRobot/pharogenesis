color: aColor
	color = aColor ifTrue:[^self].
	color _ aColor.
	self releaseCachedState.