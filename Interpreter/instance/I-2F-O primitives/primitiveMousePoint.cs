primitiveMousePoint
	"Return a Point indicating current position of the mouse. Note that mouse coordinates may be negative if the mouse moves above or to the left of the top-left corner of the Smalltalk window."

	| pointWord x y |
	self pop: 1.
	pointWord _ self ioMousePoint.
	x _ self signExtend16: ((pointWord >> 16) bitAnd: 16rFFFF).
	y _ self signExtend16: (pointWord bitAnd: 16rFFFF).
	self push: (self makePointwithxValue: x  yValue: y).