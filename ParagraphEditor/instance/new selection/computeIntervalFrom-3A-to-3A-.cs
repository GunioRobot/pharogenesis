computeIntervalFrom: start to: stop
	"Select the designated characters, inclusive.  Make no visual changes."

	self setMark: start.
	self setPoint: stop + 1.