keys
	"Answer a Set containing the receiver's keys."
	| aSet |
	aSet := IdentitySet new: self size.
	self keysDo: [:key | aSet add: key].
	^ aSet