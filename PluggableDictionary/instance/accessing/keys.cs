keys
	"Answer a Set containing the receiver's keys."
	| aSet |
	aSet _ PluggableSet new: self size.
	aSet equalBlock: self equalBlock fixTemps.
	aSet hashBlock: self hashBlock fixTemps.
	self keysDo: [:key | aSet add: key].
	^ aSet