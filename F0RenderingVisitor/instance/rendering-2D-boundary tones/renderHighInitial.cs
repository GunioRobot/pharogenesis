renderHighInitial
	"Render a %H tone."
	| start stop |
	start _ 0.
	stop _ self initialStopTime.
	self time: start
		startingF0: (contour at: start)
		amplitude: self highPitch - (contour at: start) * 2
		duration: stop - start
		peakPosition: start
		tilt: 0.0