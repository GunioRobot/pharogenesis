knownSketchCostumeWithSameFormAs: aSketchMorph
	| itsForm |
	itsForm _ aSketchMorph form.
	^ costumes ifNotNil: [costumes detect: [:c | (c isKindOf: SketchMorph) and: [c form == itsForm]]
					ifNone: [nil]]