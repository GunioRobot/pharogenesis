getRedComponentIn: aPatch

	| pix xArray yArray patch w |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	patch _ aPatch costume renderedMorph.
	w _ WordArray new: self size.
	1 to: self size do: [:i |
		pix _ patch pixelAtX: (xArray at: i) y: (yArray at: i).
		w at: i put: ((pix bitShift: -16) bitAnd: 16rFF).
	].
	^ w.
