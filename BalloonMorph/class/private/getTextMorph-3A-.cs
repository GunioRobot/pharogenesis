getTextMorph: aStringOrMorph
	"Construct text morph."

	| m text |
	aStringOrMorph isMorph
		ifTrue: [m _ aStringOrMorph]
		ifFalse:
			[BalloonFont
				ifNil: [text _ aStringOrMorph]
				ifNotNil: [text _ Text
					string: aStringOrMorph
					attribute: (TextFontReference toFont: BalloonFont)].
			m _ (TextMorph new contents: text) centered].
	m setToAdhereToEdge: #adjustedCenter.
	^ m