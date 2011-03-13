testNullCategory
	"Test that category 'as yet unclassified' disapears when all it's elements are removed'"
	| aCategorizer |
	aCategorizer := Categorizer defaultList: #().
	self assert: aCategorizer printString =
'(''as yet unclassified'')
'.
	self assert: aCategorizer categories = #('no messages').
	aCategorizer classify: #a under: #b.
	self assert: aCategorizer printString =
'(''b'' a)
'.
	self assert: aCategorizer categories = #(b).