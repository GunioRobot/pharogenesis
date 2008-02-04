newTextStyleFromTT: descriptionArray

	| array f textStyle styleName arrayOfArray |

	arrayOfArray := self pointSizes collect: [:pt |
		descriptionArray collect: [:ttc |
			ttc ifNil: [nil] ifNotNil: [
				f := (ttc size > 256)
					ifTrue: [MultiTTCFont new initialize]
					ifFalse: [TTCFont new initialize].
				f ttcDescription: ttc.
				f pointSize: pt.
			].
		].
	].

	array := arrayOfArray collect: [:fonts |
		self newFontArray: fonts.
	].

	styleName := (array at: 1) familyName asSymbol.
	textStyle := TextStyle fontArray: array.
	TextConstants at: styleName put: textStyle.

	self register: array at: styleName.

	^ TextConstants at: styleName.
