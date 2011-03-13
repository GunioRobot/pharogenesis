new: nElements
	"Create a Set large enough to hold nElements without growing"
	^ super basicNew initialize: (self sizeFor: nElements)