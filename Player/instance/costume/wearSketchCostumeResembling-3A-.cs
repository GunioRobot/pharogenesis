wearSketchCostumeResembling: aSketchMorph
	| newCostume itsForm cur degs chgd |
	itsForm _ aSketchMorph form.
	((cur _ costume renderedMorph) isKindOf: SketchMorph)
		ifTrue:
			[cur form == itsForm ifTrue: [^ self]].

	(costumes notNil and: [costumes size > 0]) ifTrue:
		[newCostume _ costumes detect: [:c | (c isKindOf: SketchMorph) and: [c form == itsForm]]
					ifNone: [nil]].
	chgd _ false.
	newCostume ifNil:
		[newCostume _ SketchMorph new player: self.
		newCostume originalForm: itsForm;
			rotationCenter: aSketchMorph rotationCenter;
			framesToDwell: aSketchMorph framesToDwell;
			rotationStyle: aSketchMorph rotationStyle.
		chgd _ true].
	((cur isKindOf: SketchMorph) and: [cur rotationStyle ~~ #normal])
			ifTrue:
				[newCostume rotationStyle: cur rotationStyle.
				newCostume rotationDegrees: cur rotationDegrees.
				degs _ cur valueOfProperty: #setupAngle ifAbsent: [nil].
				degs ifNotNil: [newCostume setupAngle: degs].
				chgd _ true].
	chgd ifTrue: [newCostume layoutChanged].
	self renderedCostume: newCostume