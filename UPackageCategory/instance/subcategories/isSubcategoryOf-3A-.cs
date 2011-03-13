isSubcategoryOf: prefix
	components isEmpty ifTrue: [ ^false ].
	^components allButLast = prefix components