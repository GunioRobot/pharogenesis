addTextToButton: aStringOrText

	| tm existing |

	existing _ self currentTextMorphsInButton.
	existing do: [ :x | x delete].
	aStringOrText ifNil: [^self].
	tm _ TextMorph new contents: aStringOrText.
	tm 
		fullBounds;
		lock;
		align: tm center with: visibleMorph center;
		setProperty: #textAddedByButtonProperties toValue: true;
		setToAdhereToEdge: #center.
	"maybe the user would like personal control here"
	"visibleMorph extent: (tm extent * 1.5) rounded."
	visibleMorph addMorphFront: tm.
