testClassifyNewElementOldCategory
	categorizer classify: #f under: #unreal.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' a b c)
(''unreal'' f)
'