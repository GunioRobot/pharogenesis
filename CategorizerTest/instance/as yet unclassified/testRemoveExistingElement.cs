testRemoveExistingElement
	categorizer removeElement: #a.
	self assert: categorizer printString =
'(''as yet unclassified'' d e)
(''abc'' b c)
(''unreal'')
'