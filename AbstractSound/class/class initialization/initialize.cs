initialize
	"AbstractSound initialize"
 
	ScaleFactor _ 2 raisedTo: 15.
	MaxScaledValue _ ((2 raisedTo: 31) // ScaleFactor) - 1.  "magnitude of largest scaled value in 32-bits"