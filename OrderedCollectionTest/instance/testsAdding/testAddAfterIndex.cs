testAddAfterIndex

	| l |
	l := #(1 2 3 4) asOrderedCollection.
	l add: 88 afterIndex: 1.
	self assert: (l =  #(1 88 2 3 4) asOrderedCollection).
	l add: 99 afterIndex: 2.
	self assert: (l =  #(1 88 99 2 3 4) asOrderedCollection). 

