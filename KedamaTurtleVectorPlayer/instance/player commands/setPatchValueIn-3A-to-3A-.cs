setPatchValueIn: aPatch to: value

	| xArray yArray patchMorph |
	xArray _ arrays at: 2.
	yArray _ arrays at: 3.
	patchMorph _ aPatch costume renderedMorph.
	patchMorph setPixelsAtXArray: xArray yArray: yArray value: value.

