setStandardTexture
	| parms |
	parms _ self textureParameters.
	self  makeGraphPaperGrid: parms first background: parms second line: parms third.
	self fullRepaintNeeded