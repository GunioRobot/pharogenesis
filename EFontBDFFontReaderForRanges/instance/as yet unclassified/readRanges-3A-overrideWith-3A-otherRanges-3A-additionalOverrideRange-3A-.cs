readRanges: ranges overrideWith: otherFileName otherRanges: otherRanges additionalOverrideRange: additionalRange

	| xTable strikeWidth glyphs ascent descent minAscii maxAscii maxWidth chars charsNum height form encoding bbx width blt lastAscii pointSize ret lastValue start end |
	form _ encoding _ bbx _ nil.
	self initialize.
	self readAttributes.
	height _ Integer readFromString: ((properties at: #FONTBOUNDINGBOX) at: 2).
	ascent _ Integer readFromString: (properties at: 'FONT_ASCENT' asSymbol) first.
	descent _ Integer readFromString: (properties at: 'FONT_DESCENT' asSymbol) first.
	(properties includesKey: 'POINT_SIZE' asSymbol) ifTrue: [
		pointSize _ (Integer readFromString: (properties at: 'POINT_SIZE' asSymbol) first) // 10.
	] ifFalse: [
		pointSize _ (ascent + descent) * 72 // 96.
	].
		
	
	maxWidth _ 0.
	minAscii _ 16r200000.
	strikeWidth _ 0.
	maxAscii _ 0.

	charsNum _ Integer readFromString: (properties at: #CHARS) first.
	chars _ Set new: charsNum.

	self readCharactersInRanges: ranges storeInto: chars.
	chars _ self override: chars with: otherFileName ranges: otherRanges transcodingTable: (UCSTable jisx0208Table) additionalRange: additionalRange.

	chars _ chars asSortedCollection: [:x :y | (x at: 2) <= (y at: 2)].
	charsNum _ chars size. "undefined encodings make this different"
	
	chars do: [:array |
		encoding _ array at: 2.
		bbx _ array at: 3..
		width _ bbx at: 1.
		maxWidth _ maxWidth max: width.
		minAscii _ minAscii min: encoding.
		maxAscii _ maxAscii max: encoding.
		strikeWidth _ strikeWidth + width.
	].

	glyphs _ Form extent: strikeWidth@height.
	blt _ BitBlt toForm: glyphs.
	start _ ((ranges collect: [:r | r first]), (additionalRange collect: [:r2 | r2 first])) min.
	end _ ((ranges collect: [:r | r second]), (additionalRange collect: [:r2 | r2 second])) max + 3.
	"xRange _ Array with: (Array with: ((ranges collect: [:r | r first]), (additionalRange collect: [:r2 | r2 first])) min
						with: (((ranges collect: [:r | r second]), (additionalRange collect: [:r2 | r2 second])) max + 2))."
	"xTable _ XTableForUnicodeFont new
		ranges: xRange."
	xTable _ SparseLargeTable new: end chunkSize: 64 arrayClass: Array base: start defaultValue: -1.
	lastAscii _ start.
	xTable at: lastAscii + 2 put: 0.
	1 to: charsNum do: [:i |
		form _ (chars at: i) first.
		encoding _ (chars at: i) second.
		bbx _ (chars at: i) third.
		"lastAscii+1 to: encoding-1 do: [:a | xTable at: a+2 put: (xTable at: a+1)]."
		lastValue _ xTable at: lastAscii + 1 + 1.
		xTable at: encoding + 1 put: lastValue.
		blt copy: (((xTable at: encoding+1)@(ascent - (bbx at: 2) - (bbx at: 4)))
				extent: (bbx at: 1)@(bbx at: 2))
			from: 0@0 in: form.
		xTable at: encoding+2 put: (xTable at: encoding+1)+(bbx at: 1).
		lastAscii _ encoding.
	].
	xTable at: xTable size put: (xTable at: xTable size - 1).
	xTable zapDefaultOnlyEntries.
	ret _ Array new: 8.
	ret at: 1 put: xTable.
	ret at: 2 put: glyphs.
	ret at: 3 put: minAscii.
	ret at: 4 put: maxAscii.
	ret at: 5 put: maxWidth.
	ret at: 6 put: ascent.
	ret at: 7 put: descent.
	ret at: 8 put: pointSize.
	^ret.
" ^{xTable. glyphs. minAscii. maxAscii. maxWidth. ascent. descent. pointSize}"
