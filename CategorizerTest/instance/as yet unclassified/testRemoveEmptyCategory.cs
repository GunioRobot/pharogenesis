testRemoveEmptyCategory
	categorizer removeCategory: #unreal.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' a b c)
'