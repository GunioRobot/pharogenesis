resetViewBox
	| c |
	(c := worldState canvas) isNil ifTrue: [^self resetViewBoxForReal].
	c form == Display ifFalse: [^self resetViewBoxForReal].
	c origin = (0 @ 0) ifFalse: [^self resetViewBoxForReal].
	c clipRect extent = self viewBox extent 
		ifFalse: [^self resetViewBoxForReal]