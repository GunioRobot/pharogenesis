allInstances 
	"Answer a Set of all current instances of the receiver."

	| aCollection |
	aCollection _ OrderedCollection new.
	self allInstancesDo:
		[:x | x == aCollection ifFalse: [aCollection add: x]].
	^aCollection