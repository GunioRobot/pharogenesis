setContent: aString
	| textMorphs textMorph |
	textMorphs := self dependents select: [:c | c isKindOf: PluggableTextMorph].
	textMorphs ifEmpty: [ ^ true ]. "This case should normally not happen"
	
	textMorph := textMorphs first.
	textMorph setText: aString