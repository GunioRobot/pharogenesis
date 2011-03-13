withAllSubclasses
	"Answer a Set of the receiver, the receiver's descendent's, and the 
	receiver's descendent's subclasses."

	| aSet |
	aSet _ Set with: self.
	aSet addAll: self subclasses.
	self subclasses do: [:eachSubclass | aSet addAll: eachSubclass allSubclasses].
	^aSet