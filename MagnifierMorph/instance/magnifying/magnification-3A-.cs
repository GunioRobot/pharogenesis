magnification: aNumber
	| c |  
	magnification _ aNumber min: 8 max: 0.5.
	magnification _ magnification roundTo:
		(magnification < 3 ifTrue: [0.5] ifFalse: [1]).
	srcExtent _ srcExtent min: (512@512) // magnification. "to prevent accidents"
	c _ self center.
	super extent: self defaultExtent.
	self center: c.