initialize
	"initialize the state of the receiver"
	random _ Random new.
	sneaky _ random next < 0.75.
	super initialize.
""
	self beSmoothCurve; initializeBlobShape; setVelocity