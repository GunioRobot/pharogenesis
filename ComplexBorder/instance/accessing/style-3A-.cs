style: newStyle
	style == newStyle ifTrue:[^self].
	style _ newStyle.
	self releaseCachedState.