asFormWithSingleTransparentColors
	| transparentIndexes |
	transparentIndexes _ self transparentColorIndexes.
	transparentIndexes size <= 1 ifTrue:[^self]
		ifFalse:[^self mapTransparencies:transparentIndexes].