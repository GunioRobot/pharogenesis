loadWideLine: lineWidth from: p1 to: p2 lineFill: lineFill leftFill: leftFill rightFill: rightFill
	"Load a (possibly wide) line defined by the points p1 and p2"
	| line offset |
	self var: #p1 declareC:'int *p1'.
	self var: #p2 declareC:'int *p2'.
	(lineWidth = 0 or:[lineFill = 0])
		ifTrue:[	line _ self allocateLine.
				offset _ 0]
		ifFalse:[	line _ self allocateWideLine.
				offset _ self offsetFromWidth: lineWidth].
	engineStopped ifTrue:[^0].
	self loadLine: line 
		from: p1
		to: p2
		offset: offset 
		leftFill: leftFill
		rightFill: rightFill.
	(self isWide: line) ifTrue:[
		self wideLineFillOf: line put: lineFill.
		self wideLineWidthOf: line put: lineWidth.
		self wideLineExtentOf: line put: lineWidth].