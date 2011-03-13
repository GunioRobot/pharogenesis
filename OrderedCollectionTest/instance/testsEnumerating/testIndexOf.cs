testIndexOf
	| collection indices |
	collection := #('Jim' 'Mary' 'John' 'Andrew' ) asOrderedCollection.
	indices := collection
				collect: [:item | collection indexOf: item].
	self assert: (1 to: 4) asOrderedCollection = indices