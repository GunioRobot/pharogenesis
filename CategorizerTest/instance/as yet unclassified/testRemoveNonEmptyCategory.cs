testRemoveNonEmptyCategory
	self should: [categorizer removeCategory: #abc] raise: Error.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' a b c)
(''unreal'')
'