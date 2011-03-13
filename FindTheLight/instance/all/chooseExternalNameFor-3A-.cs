chooseExternalNameFor: anObject
	"The intent here is for the e-toy, within limits, to allocate these names"
	|  count names |
	names _ self playfield world allKnownNames.
	count _ self playfield submorphs size.
	(count == 1 and: [(names includes: 'moth') not]) ifTrue: [^ 'moth'].
	(count == 2 and: [(names includes: 'light') not]) ifTrue: [^ 'light'].
	^ super chooseExternalNameFor: anObject
