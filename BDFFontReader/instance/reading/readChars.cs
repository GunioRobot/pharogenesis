readChars
	| strikeWidth ascent descent minAscii maxAscii maxWidth chars charsNum height form encoding bbx array width pointSize stream |
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

	^ chars.
