nextAndClose
	"Speedy way to grab one object.  Only use when we are inside an object binary file.  Do not use for the start of a SmartRefStream mixed code-and-object file."

	| obj |
	obj _ self next.
	self close.
	^ obj