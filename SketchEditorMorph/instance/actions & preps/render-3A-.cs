render: damageRect
	"Compose the damaged area again and store on the display.  damageRect is relative to paintingForm origin.  3/19/97 tk"

	self invalidRect: damageRect.	"Now in same coords as self bounds"

"	| rect |
	rect _ damageRect translateBy: composite.	just within this window
	dimToComp destRect: rect; 
		sourceOrigin: damageRect origin; copyBits.
	picToComp destRect: rect; 
		sourceOrigin: damageRect origin; copyBits.
	rotationButton copyBits.
	scaleButton copyBits.
	compToDisplay sourceRect: rect; 
		destOrigin: canvasRectangle origin + damageRect origin; copyBits.
"