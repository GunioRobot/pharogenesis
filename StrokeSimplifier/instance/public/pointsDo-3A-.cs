pointsDo: aBlock
	firstPoint ifNil:[^self].
	firstPoint do: aBlock.