fromHostFont: fontName size: fontSize flags: fontFlags weight: fontWeight
	"
		^StrikeFont fromHostFont: (StrikeFont hostFontFromUser)
					size: 12 flags: 0 weight: 4.
	"
	| fontHandle glyphs xTable xStart maxWidth w glyphForm ascent descent fontHeight |
	fontHandle _ self primitiveCreateFont: fontName size: fontSize flags: fontFlags weight: fontWeight.
	ascent _ self primitiveFontAscent: fontHandle.
	descent _ self primitiveFontDescent: fontHandle.
	fontHeight _ ascent + descent.
	xTable _ Array new: 258.
	xStart _ maxWidth _ 0.
	0 to: 255 do:[:i|
		xTable at: i+1 put: xStart.
		w _ self primitiveFont: fontHandle widthOfChar: i.
		w > maxWidth ifTrue:[maxWidth _ w].
		xStart _ xStart + w].
	xTable at: 256 put: xStart.
	xTable at: 257 put: xStart.
	xTable at: 258 put: xStart.
	glyphs _ Form extent: xTable last @ fontHeight depth: 1.
	glyphForm _ Form extent: maxWidth @ fontHeight depth: 1.
	0 to: 255 do:[:i|
		glyphForm fillWhite.
		self primitiveFont: fontHandle glyphOfChar: i into: glyphForm.
		xStart _ xTable at: i+1.
		glyphForm displayOn: glyphs at: xStart@0.
		glyphForm displayOn: Display at: xStart@0.
	].
	self primitiveDestroyFont: fontHandle.
	^Array with: glyphs with: xTable