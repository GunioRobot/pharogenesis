comeToFront
	| outerMorph |
	outerMorph _ self topRendererOrSelf.
	(outerMorph owner == nil or: [outerMorph owner hasSubmorphs not]) ifTrue: [^ self].
	outerMorph owner firstSubmorph == outerMorph ifFalse:
		[outerMorph owner addMorphFront: outerMorph]