repeatValue: delta max: maxValue
	| newDelta |
	self inline: true.
	newDelta _ delta.
	[newDelta < 0] whileTrue:[newDelta _ newDelta + maxValue].
	[newDelta >= maxValue] whileTrue:[newDelta _ newDelta - maxValue].
	^newDelta