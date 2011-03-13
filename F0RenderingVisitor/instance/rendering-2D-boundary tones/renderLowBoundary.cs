renderLowBoundary
	"Render a L% boundary tone."
	| start stop |
	start := self boundaryStartTime.
	stop := self boundaryStopTime.
	self time: start
		startingF0: (contour at: start)
		amplitude: (contour at: start) - self lowPitch
		duration: stop - start
		peakPosition: stop - start
		tilt: -1.0