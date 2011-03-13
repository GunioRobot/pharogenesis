colorToPatch: aPatch

	| xArray yArray cArray patch |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	cArray _ arrays at: 5.
	patch _ aPatch costume renderedMorph.
	1 to: self size do: [:i |
		patch pixelAtX: (xArray at: i) y: (yArray at: i) put: (cArray at: i).
	].
