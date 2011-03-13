testReversed
	
	| sc1 sc2 sc3 |
	sc1 := #(1 2 3 4) asSortedCollection.
	self assert: sc1 reversed asArray = sc1 asArray reversed.
	
	self
		assert: sc1 reversed class = SortedCollection
		description: 'reversing a SortedCollection should answer a SortedCollection'.
	
	sc1 removeFirst; removeLast.
	sc2 := sc1 reversed.
	self assert: sc2 reversed asArray = sc1 asArray.
	
	sc2 add: 3/2; add: 1/2; add: 7/2.
	self assert: sc2 asArray = {7/2. 3. 2. 3/2. 1/2}.
	
	
	sc3 := #(1 2 3 3.0 4) asSortedCollection.
	self assert: sc3 reversed asArray = #(4 3.0 3 2 1).
	self assert: (sc3 reversed at: 2) class = Float.
	