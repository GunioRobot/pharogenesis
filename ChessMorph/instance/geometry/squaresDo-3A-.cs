squaresDo: aBlock
	^submorphs do:[:m| (m hasProperty: #squarePosition) ifTrue:[aBlock value: m]].