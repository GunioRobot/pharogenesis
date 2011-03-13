keys
	"Answer a Set containing the receiver's keys."
	| aSet |
	aSet := PluggableSet new: self size.
	self equalBlock ifNotNil: [aSet equalBlock: self equalBlock].
	self hashBlock ifNotNil: [aSet hashBlock: self hashBlock].
	self keysDo: [:key | aSet add: key].
	^ aSet