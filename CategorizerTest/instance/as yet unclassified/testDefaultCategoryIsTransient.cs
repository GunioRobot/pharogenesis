testDefaultCategoryIsTransient
	"Test that category 'as yet unclassified' disapears when all it's elements are removed'"
	categorizer classifyAll: #(d e) under: #abc.
	self assert: categorizer printString =
'(''abc'' a b c d e)
(''unreal'')
'