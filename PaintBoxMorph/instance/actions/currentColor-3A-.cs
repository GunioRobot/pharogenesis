currentColor: aColor
	"Accept a color from the outside.  (my colorMemoryMorph must call takeColorEvt: evt from: colorPicker instead)"

	currentColor _ aColor.
	colorMemory currentColor: aColor.
	self showColor.
	self colorable ifFalse: [self setAction: #paint:].	"User now thinking of painting"