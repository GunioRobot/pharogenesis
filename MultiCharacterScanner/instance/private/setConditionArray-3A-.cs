setConditionArray: aSymbol

	aSymbol == #paddedSpace ifTrue: [^stopConditions _ PaddedSpaceCondition "copy"].
	"aSymbol == #space ifTrue: [^stopConditions _ SpaceCondition copy]."
	aSymbol == nil ifTrue: [^stopConditions _ NilCondition "copy"].
	self error: 'undefined stopcondition for space character'.
