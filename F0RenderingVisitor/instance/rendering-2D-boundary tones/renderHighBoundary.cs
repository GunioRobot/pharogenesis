renderHighBoundary
	"Render a H% boundary tone."
	| start stop |
	start _ self boundaryStartTime.
	stop _ self boundaryStopTime.
	self time: start
		startingF0: (contour at: start)
		amplitude: self highPitch - (contour at: start)
		duration: stop - start
		peakPosition: stop - start
		tilt: 1.0