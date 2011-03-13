testSize
	"Allows one to check the size of an Ordered collection"
	"self run:#testSize"
	
	| c1 c2 |
	c1 := #(1 2 ) asOrderedCollection.
	self assert: (c1 size =  2).
	
	c2 := OrderedCollection new.
	self assert: (c2 size = 0)
	