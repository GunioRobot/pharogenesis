getPatchValueIn: aPatch

	| w patch xArray yArray |
	w _ WordArray new: self size.
	patch _ aPatch costume renderedMorph.
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	patch pixelsAtXArray: xArray yArray: yArray into: w.
	^ w.
