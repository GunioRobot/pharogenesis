keys
	"Answer a Set containing the receiver's keys."
	| aSet |
	aSet _ Set new: self size.
	self keysDo: [:key | aSet add: key].
	^ aSet