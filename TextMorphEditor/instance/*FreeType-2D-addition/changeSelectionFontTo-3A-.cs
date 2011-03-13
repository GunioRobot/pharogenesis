changeSelectionFontTo: aFont

	| attr startIndex stopIndex f  code textIsBold textIsItalic copy fontIsBold fontIsItalic style squeakBoldEmphasis squeakItalicEmphasis |
	
	aFont ifNil:[^self].
	startIndex := self startIndex.
	stopIndex := self stopIndex-1 min: paragraph text size.
	f := aFont. 
	squeakBoldEmphasis := 1.
	squeakItalicEmphasis := 2.
	(f isKindOf: LogicalFont)
		ifTrue:[
			copy := f copy 
				forceNotBold;
				forceNotItalic;
				clearRealFont;
				yourself.
			LogicalFont all remove: copy ifAbsent:[]. "remove the copy from all before getting another one"
			f := LogicalFont 
				familyName: copy familyName 
				pointSize: copy pointSize 
				stretchValue: copy stretchValue
				weightValue: copy weightValue
				slantValue: copy slantValue.
			"add aFont's emphasis to the text as a separate action"
			code := paragraph text emphasisAt: startIndex. 
			textIsBold :=  code anyMask: squeakBoldEmphasis.
			textIsItalic := code anyMask: squeakItalicEmphasis.
			(aFont isBoldOrBolder ~= textIsBold) 
				ifTrue:[self setEmphasis: #bold  "toggle bold"].
			(aFont isItalicOrOblique ~= textIsItalic) 
				ifTrue:[self setEmphasis: #italic "toggle italic"].
			paragraph composeAll.
			self recomputeSelection. ]
		ifFalse:["must be from a TextStyle?"
			style := TextStyle named: aFont familyName.
			style ifNil:[
				style := TextStyle actualTextStyles
					detect: [:aStyle | 
						(aStyle fontArray includes: aFont) or:[
							(aStyle fontArray select: [:e | e derivativeFonts includes: aFont]) notEmpty]]
					ifNone: []].
			f := style fontOfPointSize: aFont pointSize. "unemphasized"
			"add aFont's emphasis to the text as a separate action"
			code := paragraph text emphasisAt: startIndex. 
			textIsBold :=  code anyMask: squeakBoldEmphasis.
			textIsItalic := code anyMask: squeakItalicEmphasis.
			fontIsBold := aFont emphasis anyMask: squeakBoldEmphasis.
			fontIsItalic := aFont emphasis anyMask: squeakItalicEmphasis.
			(fontIsBold ~= textIsBold) 
				ifTrue:[self setEmphasis: #bold  "toggle bold"].
			(fontIsItalic ~= textIsItalic) 
				ifTrue:[self setEmphasis: #italic "toggle italic"].
			paragraph composeAll.
			self recomputeSelection. ].
	attr := TextFontReference toFont: f.
	stopIndex >= startIndex
		ifTrue: [ paragraph text addAttribute: attr from: startIndex to: stopIndex ]
		ifFalse: [ paragraph text addAttribute: attr from: 1 to: paragraph text size. ].
	paragraph composeAll.
	self recomputeInterval.
	"next bit makes it reflow and redraw correctly"
	morph updateFromParagraph. 
	morph handleEdit:[]
