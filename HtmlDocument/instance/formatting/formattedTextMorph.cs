formattedTextMorph
	"return a version of this document as a formatted TextMorph (which includes links and such)"
	| formatter text textMorph |
	formatter _ HtmlFormatter preferredFormatterClass new.
	self addToFormatter: formatter.
	text _ formatter text .

	textMorph _ TextMorph new initialize.
	textMorph contentsWrapped: text.

	^textMorph