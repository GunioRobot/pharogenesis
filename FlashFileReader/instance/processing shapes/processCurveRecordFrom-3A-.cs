processCurveRecordFrom: data
	| nBits cx cy ax ay |
	log ifNotNil:[log crtab; nextPutAll:'C: '].
	nBits _ (data nextBits: 4) + 2. "Offset by 2"
	"Read control point change"
	cx _ data nextSignedBits: nBits.
	cy _ data nextSignedBits: nBits.
	log ifNotNil:[log print: cx@cy].
	"Read anchor point change"
	ax _ data nextSignedBits: nBits.
	ay _ data nextSignedBits: nBits.
	log ifNotNil:[log nextPutAll:' -- '; print: ax@ay.
				self flushLog].
	self recordCurveSegmentTo: ax@ay with: cx@cy