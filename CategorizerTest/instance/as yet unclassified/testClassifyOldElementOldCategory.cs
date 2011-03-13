testClassifyOldElementOldCategory
	categorizer classify: #e under: #unreal.
	self assert: categorizer printString =
'(''as yet unclassified'' d)
(''abc'' a b c)
(''unreal'' e)
'