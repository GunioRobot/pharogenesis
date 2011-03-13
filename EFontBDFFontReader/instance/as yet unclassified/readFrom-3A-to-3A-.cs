readFrom: start to: end

	| xTable strikeWidth glyphs ascent descent minAscii maxAscii maxWidth chars charsNum height form encoding bbx width blt lastAscii pointSize ret lastValue |
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

	self readCharactersInRangeFrom: start to: end totalNums: charsNum storeInto: chars.

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
	"xTable _ XTableForUnicodeFont new ranges: (Array with: (Array with: start with: end))."
	xTable _ SparseLargeTable new: end + 3 chunkSize: 32 arrayClass: Array base: start + 1 defaultValue: -1.
	lastAscii _ start.	
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
