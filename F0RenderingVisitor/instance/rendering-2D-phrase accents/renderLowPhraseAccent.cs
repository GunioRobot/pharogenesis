renderLowPhraseAccent
	"Render a L- accent."
	| start stop |
	start _ self phraseAccentStartTime.
	stop _ self phraseAccentStopTime.
	self time: start
		startingF0: (contour at: start)
		amplitude: (contour at: start) - self lowPitch
		duration: stop - start
		peakPosition: stop - start
		tilt: -0.5