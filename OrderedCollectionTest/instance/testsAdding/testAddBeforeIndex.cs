testAddBeforeIndex

	| l |
	l := #(1 2 3 4) asOrderedCollection.
	l add: 88 beforeIndex: 1.
	self assert: (l =  #(88 1 2 3 4) asOrderedCollection).
	l add: 99 beforeIndex: 2.
	self assert: (l =  #(88 99 1 2 3 4) asOrderedCollection). 

