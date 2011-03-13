read
	| xTable strikeWidth glyphs ascent descent minAscii maxAscii maxWidth chars charsNum height form encoding bbx array width blt lastAscii pointSize ret stream |
	form _ encoding _ bbx _ nil.
	self readAttributes.
	height _ Integer readFromString: ((properties at: #FONTBOUNDINGBOX) at: 2).
	ascent _ Integer readFromString: (properties at: 'FONT_ASCENT' asSymbol) first.
	descent _ Integer readFromString: (properties at: 'FONT_DESCENT' asSymbol) first.
	pointSize _ (Integer readFromString: (properties at: 'POINT_SIZE' asSymbol) first) // 10.
	
	maxWidth _ 0.
	minAscii _ 9999.
	strikeWidth _ 0.
	maxAscii _ 0.

	charsNum _ Integer readFromString: (properties at: #CHARS) first.
	chars _ Set new: charsNum.

	1 to: charsNum do: [:i |
		array _ self readOneCharacter.
		stream _ ReadStream on: array.
		form _ stream next.
		encoding _ stream next.
		bbx _ stream next.
		form ifNotNil: [
			width _ bbx at: 1.
			maxWidth _ maxWidth max: width.
			minAscii _ minAscii min: encoding.
			maxAscii _ maxAscii max: encoding.
			strikeWidth _ strikeWidth + width.
			chars add: array.
		].
	].

	chars _ chars asSortedCollection: [:x :y | (x at: 2) <= (y at: 2)].
	charsNum _ chars size. "undefined encodings make this different"

	charsNum > 256 ifTrue: [
		"it should be 94x94 charset, and should be fixed width font"
		strikeWidth _ 94*94*maxWidth.
		maxAscii _ 94*94.
		minAscii _ 0.
		xTable _ XTableForFixedFont new.
		xTable maxAscii: 94*94.
		xTable width: maxWidth.
	] ifFalse: [
		xTable _ (Array new: 258) atAllPut: 0.
	].

	glyphs _ Form extent: strikeWidth@height.
	blt _ BitBlt toForm: glyphs.
	lastAscii _ 0.
	
	charsNum > 256 ifTrue: [
		1 to: charsNum do: [:i |
			stream _ ReadStream on: (chars at: i).
			form _ stream next.
			encoding _ stream next.
			bbx _ stream next.
			encoding _ ((encoding // 256) - 33) * 94 + ((encoding \\ 256) - 33).
			blt copy: ((encoding * maxWidth)@0 extent: maxWidth@height)
				from: 0@0 in: form.
		].
	] ifFalse: [
		1 to: charsNum do: [:i |
			stream _ ReadStream on: (chars at: i).
			form _ stream next.
			encoding _ stream next.
			bbx _ stream next.
			lastAscii+1 to: encoding-1 do: [:a | xTable at: a+2 put: (xTable at: a+1)].
			blt copy: (((xTable at: encoding+1)@(ascent - (bbx at: 2) - (bbx at: 4)))
					extent: (bbx at: 1)@(bbx at: 2))
				from: 0@0 in: form.
			xTable at: encoding+2 put: (xTable at: encoding+1)+(bbx at: 1).
			lastAscii _ encoding.
		]
	].

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
