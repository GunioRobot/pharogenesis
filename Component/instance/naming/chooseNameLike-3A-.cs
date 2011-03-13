chooseNameLike: someName 
	| stem otherNames i partName |
	stem _ someName.
	(stem size > 5 and: [stem endsWith: 'Morph'])
		ifTrue: [stem _ stem copyFrom: 1 to: stem size - 5].
	stem _ stem first asLowercase asString , stem allButFirst.
	otherNames _ self class allInstVarNames asSet.
	"otherNames addAll: self world allKnownNames."
	i _ 1.
	[otherNames includes: (partName _ stem , i printString)]
		whileTrue: [i _ i + 1].
	partName _ FillInTheBlank request: 'Please give this part a name'
						initialAnswer: partName.
	partName isEmpty ifTrue: [^ nil].
	(otherNames includes: partName) ifTrue:
			[self inform: 'Sorry, that name is already used'.
			^ nil].
	^ partName