isEmptyCategoryNamed: categoryName
	| i |
	i _ categoryArray indexOf: categoryName ifAbsent: [^false].
	^self isEmptyCategoryNumber: i