resetViewBox

	| c |
	(c _ self canvas) == nil ifTrue: [^self resetViewBoxForReal].
	c form == Display ifFalse: [^self resetViewBoxForReal].
	c origin = (0@0) ifFalse: [^self resetViewBoxForReal].
	c clipRect extent = (self viewBox intersect: parentWorld viewBox) extent ifFalse: [^self resetViewBoxForReal].
			
