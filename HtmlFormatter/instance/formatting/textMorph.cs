textMorph
	| text textMorph |
	text _ outputStream contents.
	textMorph _ TextMorph new contents: text.
	morphsToEmbed do:[ :m | textMorph addMorph: m ].
	^textMorph