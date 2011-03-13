chooseExternalNameFor: anObject
	"The intent here is for the e-toy, within limits, to allocate these names"
	|  count names |
	names _ self playfield world allKnownNames.
	count _ self playfield submorphs size.
	(count == 1 and: [(names includes: 'car') not]) ifTrue: [^ 'car'].
	(count == 2 and: [(names includes: 'steering') not]) ifTrue: [^ 'steering'].
	^ super chooseExternalNameFor: anObject
