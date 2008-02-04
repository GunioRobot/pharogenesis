readFrom: start to: end

	| xTable strikeWidth glyphs ascent descent minAscii maxAscii maxWidth chars charsNum height form encoding bbx width blt lastAscii pointSize ret lastValue |
	form := encoding := bbx := nil.
	self initialize.
	self readAttributes.
	height := Integer readFromString: ((properties at: #FONTBOUNDINGBOX) at: 2).
	ascent := Integer readFromString: (properties at: 'FONT_ASCENT' asSymbol) first.
	descent := Integer readFromString: (properties at: 'FONT_DESCENT' asSymbol) first.
	(properties includesKey: 'POINT_SIZE' asSymbol) ifTrue: [
		pointSize := (Integer readFromString: (properties at: 'POINT_SIZE' asSymbol) first) // 10.
	] ifFalse: [
		pointSize := (ascent + descent) * 72 // 96.
	].
		
	
	maxWidth := 0.
	minAscii := 16r200000.
	strikeWidth := 0.
	maxAscii := 0.

	charsNum := Integer readFromString: (properties at: #CHARS) first.
	chars := Set new: charsNum.

	self readCharactersInRangeFrom: start to: end totalNums: charsNum storeInto: chars.

	chars := chars asSortedCollection: [:x :y | (x at: 2) <= (y at: 2)].
	charsNum := chars size. "undefined encodings make this different"

	chars do: [:array |
		encoding := array at: 2.
		bbx := array at: 3..
		width := bbx at: 1.
		maxWidth := maxWidth max: width.
		minAscii := minAscii min: encoding.
		maxAscii := maxAscii max: encoding.
		strikeWidth := strikeWidth + width.
	].
	glyphs := Form extent: strikeWidth@height.
	blt := BitBlt toForm: glyphs.
	"xTable := XTableForUnicodeFont new ranges: (Array with: (Array with: start with: end))."
	xTable := SparseLargeTable new: end + 3 chunkSize: 32 arrayClass: Array base: start + 1 defaultValue: -1.
	lastAscii := start.	
	1 to: charsNum do: [:i |
		form := (chars at: i) first.
		encoding := (chars at: i) second.
		bbx := (chars at: i) third.
		"lastAscii+1 to: encoding-1 do: [:a | xTable at: a+2 put: (xTable at: a+1)]."
		lastValue := xTable at: lastAscii + 1 + 1.
		xTable at: encoding + 1 put: lastValue.
		blt copy: (((xTable at: encoding+1)@(ascent - (bbx at: 2) - (bbx at: 4)))
				extent: (bbx at: 1)@(bbx at: 2))
			from: 0@0 in: form.
		xTable at: encoding+2 put: (xTable at: encoding+1)+(bbx at: 1).
		lastAscii := encoding.
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
