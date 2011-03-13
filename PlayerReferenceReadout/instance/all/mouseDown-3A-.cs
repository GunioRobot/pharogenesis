mouseDown: evt
	"Allow the user to respecify this by direct clicking"
	| aMorph |
	putSelector == #unused ifTrue: [^ self].

	Sensor waitNoButton.
	aMorph _ self world chooseClickTarget.
	aMorph ifNil: [^ self].
	objectToView perform: putSelector with: aMorph assuredCostumee.
	self changed