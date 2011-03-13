getXMLPartNamed: partName  from: xmlDoc
	| element |
	element _ xmlDoc elementAt: partName.
	(element isNil or: [ element contents isEmpty ]) ifTrue:[ ^ '' ].
	^element contents first string