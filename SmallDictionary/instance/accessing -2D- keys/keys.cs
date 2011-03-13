keys
	"Answer a Set containing the receiver's keys."
	
"	^ keys copyFrom: 1 to: size."
	| aSet |
	aSet := Set new: self size.
	self keysDo: [:key | aSet add: key].
	^ aSet
