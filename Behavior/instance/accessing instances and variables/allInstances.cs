allInstances 
	"Answer a collection of all current instances of the receiver."

	| all |
	all _ OrderedCollection new.
	self allInstancesDo: [:x | x == all ifFalse: [all add: x]].
	^ all asArray
