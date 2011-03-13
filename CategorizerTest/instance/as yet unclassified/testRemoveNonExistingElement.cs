testRemoveNonExistingElement
	categorizer removeElement: #f.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' a b c)
(''unreal'')
'