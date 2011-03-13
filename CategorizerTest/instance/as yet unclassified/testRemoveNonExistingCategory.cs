testRemoveNonExistingCategory
	categorizer removeCategory: #nice.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' a b c)
(''unreal'')
'