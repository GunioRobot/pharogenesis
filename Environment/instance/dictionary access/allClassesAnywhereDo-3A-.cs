allClassesAnywhereDo: classBlock

	| cl |
	self deepAssociationsDo:
		[:assn | cl _ assn value.
		(cl isKindOf: Class) ifTrue: [classBlock value: cl]]