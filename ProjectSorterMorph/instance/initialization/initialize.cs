initialize
	"initialize the state of the receiver"
	super initialize.
	""
	self useRoundedCorners.
	pageHolder useRoundedCorners; borderWidth: 0;
		color: (self
				gridFormOrigin: 0 @ 0
				grid: 16 @ 16
				background: Color white
				line: Color blue muchLighter)