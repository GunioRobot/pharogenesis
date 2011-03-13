testClassifyNewElementNewCategory
	categorizer classify: #f under: #nice.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' a b c)
(''unreal'')
(''nice'' f)
'