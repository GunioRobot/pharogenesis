takeColorFrom: colorPicker
	"Accept a new color from the colorMemory.  Programs use currentColor: instead.  Do not do this before the picker has a chance to set its own color!"

	currentColor _ colorPicker currentColor.
	self showColor.
	self colorable ifFalse: [self setAction: #paint:].	"User now thinking of painting"