mostSpecificPackageIn: aCollection ifNone: aBlock
	aCollection isEmpty
		ifTrue: [ ^ aBlock value ].
	^ (aCollection asArray
		sort: [ :a :b | a packageName size > b packageName size ])
		first