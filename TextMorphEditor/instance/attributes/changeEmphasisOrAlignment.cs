changeEmphasisOrAlignment
	| aList reply code align menuList startIndex alignSymbol |
	self flag: #arNote. "Move this up once we get rid of MVC"

	startIndex := self startIndex.
	aList := #(#normal #bold #italic #narrow #underlined #struckOut #leftFlush #centered #rightFlush #justified ).
	align := paragraph text
				alignmentAt: startIndex
				ifAbsent: [paragraph textStyle alignment].
	alignSymbol := TextAlignment alignmentSymbol: align.
	code := paragraph text emphasisAt: startIndex.
	menuList := Array new writeStream.
	menuList nextPut: (code isZero
			ifTrue: ['<on>']
			ifFalse: ['<off>'])
			, 'normal' translated.
	menuList
		nextPutAll: (#(#bold #italic #underlined #struckOut )
				collect: [:emph | (code anyMask: (TextEmphasis perform: emph) emphasisCode)
						ifTrue: ['<on>' , emph asString translated]
						ifFalse: ['<off>' , emph asString translated]]).
	((paragraph text attributesAt: startIndex forStyle: paragraph textStyle)
			anySatisfy: [:attr | attr isKern
					and: [attr kern < 0]])
		ifTrue: [menuList nextPut: '<on>' , 'narrow' translated]
		ifFalse: [menuList nextPut: '<off>' , 'narrow' translated].
	menuList
		nextPutAll: (#(#leftFlush #centered #rightFlush #justified )
				collect: [:type | type == alignSymbol
						ifTrue: ['<on>' , type asString translated]
						ifFalse: ['<off>' , type asString translated]]).
	aList := #(#normal #bold #italic #underlined #struckOut #narrow #leftFlush #centered #rightFlush #justified ).
	reply := UIManager default chooseFrom: menuList contents values: aList lines: #(1 6 ).
	reply ifNotNil: [
		(#(#leftFlush #centered #rightFlush #justified ) includes: reply)
				ifTrue: [self setAlignment: reply.
					paragraph composeAll.
					self recomputeInterval]
				ifFalse: [self setEmphasis: reply.
					paragraph composeAll.
					self recomputeSelection]].
	^ true