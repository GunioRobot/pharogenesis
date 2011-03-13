nameMeIn: aWorld
	| stem otherNames i partName className |
	className _ self class name.
	stem _ className.
	(stem size > 5 and: [stem endsWith: 'Morph'])
		ifTrue: [stem _ stem copyFrom: 1 to: stem size - 5].
	stem _ stem first asLowercase asString , stem allButFirst.
	otherNames _ Set newFrom: aWorld allKnownNames.
	i _ 1.
	[otherNames includes: (partName _ stem , i printString)]
		whileTrue: [i _ i + 1].
	self setNamePropertyTo: partName