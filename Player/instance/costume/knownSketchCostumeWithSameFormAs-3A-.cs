knownSketchCostumeWithSameFormAs: aSketchMorph
	| itsForm rend |
	itsForm _ aSketchMorph form.
	(((rend _ costume renderedMorph) isKindOf: SketchMorph) and: [rend form == itsForm])
		ifTrue:	[^ rend].
	^ costumes ifNotNil: [costumes detect: [:c | (c isKindOf: SketchMorph) and: [c form == itsForm]]
					ifNone: [nil]]