initialize
	"initialize the state of the receiver"
	super initialize.
	phase _ 1.
	self extent: 200 @ 200.
	ball _ EllipseMorph new extent: 30 @ 30.
	self
		addMorph: ((star _ StarMorph new extent: 150 @ 150) center: self center)