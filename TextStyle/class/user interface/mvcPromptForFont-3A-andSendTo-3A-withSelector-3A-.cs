mvcPromptForFont: aPrompt andSendTo: aTarget withSelector: aSelector
	"MVC Only! prompt for a font and if one is provided, send it to aTarget using a message with selector aSelector."
	| aMenu aChoice aStyle namesAndSizes aFont |
	"TextStyle mvcPromptForFont: 'Choose system font style' andSendTo: TextStyle withSelector: #setSystemFontTo:"
	aMenu _ CustomMenu new.
	self actualTextStyles keysSortedSafely do:
		[:styleName |
			aMenu add: styleName action: styleName].
	aChoice _ aMenu startUpWithCaption: aPrompt.
	aChoice ifNil: [^ self].
	aMenu _ CustomMenu new.
	aStyle _ self named: aChoice.
	(namesAndSizes _ aStyle fontNamesWithPointSizes) do:
		[:aString | aMenu add: aString action: aString].
	aChoice _ aMenu startUpWithCaption: nil.
	aChoice ifNil: [^ self].
	aFont _ aStyle fontAt: (namesAndSizes indexOf: aChoice).
	aTarget perform: aSelector with: aFont