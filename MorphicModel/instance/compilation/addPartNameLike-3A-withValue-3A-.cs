addPartNameLike: className withValue: aMorph
	| otherNames i default partName stem |
	stem _ className first asLowercase asString , className allButFirst.
	otherNames _ self class allInstVarNames.
	i _ 1.
	[otherNames includes: (default _ stem, i printString)]
		whileTrue: [i _ i + 1].
	partName _ FillInTheBlank
		request: 'Please give this part a name'
		initialAnswer: default.
	(otherNames includes: partName)
		ifTrue: [self inform: 'Sorry, that name is already used'. ^ nil].
	self class addInstVarName: partName.
	self instVarAt: self class instSize put: aMorph.  "Assumes added as last field"
	^ partName