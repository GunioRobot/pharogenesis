fontName: fontName size: ptSize emphasis: emphasisCode rangesArray: rangesArray
	"
		^HostFont fontName: ('MS UI Gothic') size: 12 emphasis: 0 rangesArray: EFontBDFFontReaderForRanges basicNew rangesForJapanese.
	"
	| fontHandle xStart w glyphForm fontHeight fw enc rangesStream currentRange |
	fontHandle _ self primitiveCreateFont: fontName size: ptSize emphasis: emphasisCode.
	fontHandle ifNil:[^nil].
	ranges _ rangesArray.
	ranges ifNil: [ranges _ Array with: (Array with: 0 with: 255)].
	pointSize _ ptSize.
	name _ fontName.
	emphasis _ emphasisCode.
	minAscii _ 0.
	maxAscii _ ranges last last.
	ascent _ self primitiveFontAscent: fontHandle.
	descent _ self primitiveFontDescent: fontHandle.
	kernPairs _ Array new: (self primitiveFontNumKernPairs: fontHandle).
	1 to: kernPairs size do:[:i|
		kernPairs at: i put: (self primitiveFont: fontHandle getKernPair: i)].
	fontHeight _ ascent + descent.
	xTable _ Array new: maxAscii + 3.
	fullWidth _ Array new: maxAscii + 1.
	xStart _ maxWidth _ 0.
	rangesStream _ ReadStream on: (ranges collect: [:e | (e first to: e second)]).
	currentRange _ rangesStream next.
	0 to: maxAscii do:[:i|
		xTable at: i+1 put: xStart.
		i > currentRange last ifTrue: [
			[rangesStream atEnd not and: [currentRange _ rangesStream next. currentRange last < i]] whileTrue.
			rangesStream atEnd ifTrue: [].
		].
		(currentRange includes: i) ifTrue: [
			xTable at: i+1 put: xStart.
			fw _ self primitiveFont: fontHandle fullWidthOfChar: i.
			(#(	1 "anchored morph"
				9 "tab"
				10 "LF"
				13 "CR"
			) includes: i) ifTrue:[fw := {0. 0. 0}].
			fullWidth at: i+1 put: fw.
			w _ fw at: 2.
			(fw at: 1) > 0 ifTrue:[w _ w + (fw at: 1)].
			(fw at: 3) > 0 ifTrue:[w _ w + (fw at: 3)].
			w > maxWidth ifTrue:[maxWidth _ w].
			xStart _ xStart + w].
		].
	xStart = 0 ifTrue:[^nil].
	strikeLength _ xStart.
	xTable at: maxAscii+1 put: xStart.
	xTable at: maxAscii+2 put: xStart.
	xTable at: maxAscii+3 put: xStart.
	glyphs _ Form extent: xTable last @ fontHeight depth: 1.
	glyphForm _ Form extent: maxWidth @ fontHeight depth: 1.
	0 to: maxAscii do:[:i|
		glyphForm fillWhite.
		self primitiveFont: fontHandle glyphOfChar: i into: glyphForm.
		xStart _ xTable at: i+1.
		glyphForm displayOn: glyphs at: xStart@0.
		"glyphForm displayOn: Display at: xStart@0."
	].
	enc := self primitiveFontEncoding: fontHandle.
	enc = 1 ifTrue:[characterToGlyphMap := self isoToSqueakMap].
	self primitiveDestroyFont: fontHandle.
	^self