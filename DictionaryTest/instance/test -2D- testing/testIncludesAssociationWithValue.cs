testIncludesAssociationWithValue

	| association dictionary |
	
	association := Association key: #key value: 1.
	dictionary := Dictionary new.
	dictionary add: association.
	
	self assert: (dictionary at: #key) = 1

	
	
	