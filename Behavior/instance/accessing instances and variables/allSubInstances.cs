allSubInstances 
	"Answer a list of all current instances of the receiver and all of its subclasses.  1/26/96 sw."

	| aCollection |
	aCollection _ self allInstances.
	self allSubInstancesDo:
		[:x | x == aCollection ifFalse: [aCollection add: x]].
	^ aCollection