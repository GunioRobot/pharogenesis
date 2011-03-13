testShouldPrecede
	"self run: #testShouldPrecede"
	
	|aSortedCollection|
	aSortedCollection := SortedCollection new.
	self assert: (aSortedCollection should: 'za' precede: 'zb').
	self assert: (aSortedCollection isEmpty).
	self assert: (aSortedCollection should: 1 precede: 2).
	
	aSortedCollection sortBlock: [:a :b | a > b].
	aSortedCollection reSort.
	self assert: (aSortedCollection should: 'zb' precede: 'za').
	self assert: (aSortedCollection isEmpty).
	self assert: (aSortedCollection should: 2 precede: 1).
		