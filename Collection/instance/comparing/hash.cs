hash
	"A default hash function for any collection.  Note that this method is 
	insensitive to contents when the size is greater than 10, so critical 
	applications that compare many large collections of the same length 
	will want to refine this behavior."

	| hash |
	hash _ self species hash.
	self size <= 10 ifTrue: [self do: [:elem | hash _ hash bitXor: elem hash]].
	^ hash bitXor: self size hash