initialize

	super initialize.
	xScale _ 0.25.
	yScale _ 0.25.
	radiusScale _ 1.0.
	lastAngle _ 0.0.
	autoCenter _ true.
	self form: ((Form extent: 55@55 depth: 8) fillColor: (Color r: 0.3 g: 0.2 b: 0.2)).
	handleMorph _ EllipseMorph new.
	handleMorph color: Color red; extent: 15@15.
	self addMorph: handleMorph.
	self moveHandleToCenter.
