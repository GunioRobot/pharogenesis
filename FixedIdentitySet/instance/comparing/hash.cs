hash
	"Answer an integer hash value for the receiver such that,
	  -- the hash value of an unchanged object is constant over time, and
	  -- two equal objects have equal hash values"

	| hash |
	hash _ self species hash.
	self size <= 10 ifTrue:
		[self do: [:elem | hash _ hash bitXor: elem hash]].
	^hash bitXor: self size hash