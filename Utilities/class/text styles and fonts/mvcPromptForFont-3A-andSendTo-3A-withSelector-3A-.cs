mvcPromptForFont: aPrompt andSendTo: aTarget withSelector: aSelector
        | aMenu aChoice aStyle namesAndSizes aFont |
	"Utilities mvcPromptForFont: 'Choose system font style' andSendTo: Utilities withSelector: #setSystemFontTo:"
	aMenu _ CustomMenu new.
	Utilities actualTextStyles keys do:
		[:styleName |
			aMenu add: styleName action: styleName].
	aChoice _ aMenu startUpWithCaption: aPrompt.
	aChoice ifNil: [^ self].
	aMenu _ CustomMenu new.
	aStyle _ TextStyle named: aChoice.
	(namesAndSizes _ aStyle fontNamesWithPointSizes) do:
		[:aString | aMenu add: aString action: aString].
	aChoice _ aMenu startUpWithCaption: nil.
	aChoice ifNil: [^ self].
	aFont _ aStyle fontAt: (namesAndSizes indexOf: aChoice).
	aTarget perform: aSelector with: aFont