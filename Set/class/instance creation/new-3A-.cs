new: nElements
	"Create a Set large enough to hold nElements without growing"
	^ super new init: (self sizeFor: nElements)