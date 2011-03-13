initialize
	"Initialize the receiver.
	Use the 32 bit depth default image to avoid
	unnecessary conversions."

	super initialize.
	enabled := true.
	self
		scale: 1.0;
		layout: #topLeft;
		alpha: 1.0