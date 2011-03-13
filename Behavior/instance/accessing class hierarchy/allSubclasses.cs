allSubclasses
	"Answer a Set of the receiver's and the receiver's descendent's subclasses."

	| aSet |
	aSet _ Set new.
	aSet addAll: self subclasses.
	self subclasses do: [:eachSubclass | aSet addAll: eachSubclass allSubclasses].
	^aSet