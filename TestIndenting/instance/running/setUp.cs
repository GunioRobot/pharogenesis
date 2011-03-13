setUp
	| text |
	text := 'p	' asText, (Text string: 'word word' attribute: (TextIndent tabs: 1)).
	para := text asParagraph