testClassifyOldElementNewCategory
	categorizer classify: #e under: #nice.
	self assert: categorizer printString =
'(''as yet unclassified'' d)
(''abc'' a b c)
(''unreal'')
(''nice'' e)
'