initialize
	"initialize the state of the receiver"
	super initialize.
	""
	myTarget
		ifNil: [myTarget _ RectangleMorph new openInWorld].

	thingsToRevert at: #buttonProperties: put: myTarget buttonProperties.
	self rebuild