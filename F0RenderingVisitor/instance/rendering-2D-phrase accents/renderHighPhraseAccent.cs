renderHighPhraseAccent
	"Render a H- accent."
	| start stop |
	start := self phraseAccentStartTime.
	stop := self phraseAccentStopTime.
	self time: start
		startingF0: (contour at: start)
		amplitude: self highPitch - (contour at: start)
		duration: stop - start
		peakPosition: stop - start
		tilt: 1.0