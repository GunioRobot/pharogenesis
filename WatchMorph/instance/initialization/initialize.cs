initialize
	"initialize the state of the receiver"
	super initialize.
	""

	self handsColor: Color red.
	self centerColor: Color gray.
	romanNumerals _ false.
	antialias _ false.
	fontName _ 'NewYork'.
	self extent: 130 @ 130.
	self start