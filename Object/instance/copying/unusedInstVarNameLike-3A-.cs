unusedInstVarNameLike: aName
	| stem otherNames i prospectiveName |
	stem _ aName first asLowercase asString , aName allButFirst.
	otherNames _ self class allInstVarNames.
	i _ 1.
	[otherNames includes: (prospectiveName _ stem, i printString)]
		whileTrue: [i _ i + 1].

	^ prospectiveName