namePartSilently: aMorph

	| stem otherNames i partName |
	stem _ aMorph class name.
	(stem size > 5 and: [stem endsWith: 'Morph'])
		ifTrue: [stem _ stem copyFrom: 1 to: stem size - 5].
	stem _ stem first asLowercase asString, stem allButFirst.
	otherNames _ self class allInstVarNames.
	i _ 1.
	[otherNames includes: (partName _ stem, i printString)]
		whileTrue: [i _ i + 1].
	self class addInstVarName: partName.
	self instVarAt: self class instSize put: aMorph.  "assumes added as last field"
	^ partName