getTextMorph: aStringOrMorph for: balloonOwner
	"Construct text morph."
	| m text |
	aStringOrMorph isMorph
		ifTrue: [m _ aStringOrMorph]
		ifFalse: [BalloonFont
				ifNil: [text _ aStringOrMorph]
				ifNotNil: [text _ Text
								string: aStringOrMorph
								attribute: (TextFontReference toFont: balloonOwner balloonFont)].
			m _ (TextMorph new contents: text) centered].
	m setToAdhereToEdge: #adjustedCenter.
	^ m