renderPeakAccent
	"Render a H* accent."
	| start stop peakPosition |
	start _ self syllableStartTime.
	stop _ self syllableStopTime.
	peakPosition _ (syllable events detect: [ :one | one phoneme isSyllabic] ifNone: [syllable events first]) duration / 2.0.
	self time: start
		startingF0: (contour at: start)
		amplitude: self highPitch - (contour at: start)
		duration: stop - start
		peakPosition: peakPosition
		tilt: 0.0