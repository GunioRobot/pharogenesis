keys
	"Answer a Set containing the receiver's keys."
	| aSet |
	aSet _ PluggableSet new: self size.
	self equalBlock ifNotNil: [aSet equalBlock: self equalBlock fixTemps].
	self hashBlock ifNotNil: [aSet hashBlock: self hashBlock fixTemps].
	self keysDo: [:key | aSet add: key].
	^ aSet