usablePhraseSpecsIn: aListOfPairs
	"Filter the list given by aListOfPairs if appropriate"
	self hasAnyBorderedCostumes ifTrue: [^ aListOfPairs].
	^ self hasOnlySketchCostumes
		ifTrue:
			[aListOfPairs select: [:pr | (#(color borderColor borderWidth) includes: pr second) not]]
		ifFalse:
			[aListOfPairs select: [:pr | (#(borderColor borderWidth) includes: pr second) not]]
