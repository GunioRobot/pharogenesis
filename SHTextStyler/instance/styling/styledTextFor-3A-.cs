styledTextFor: aText
	"Answer a copy of aText that is both formatted and styled"	
	| formattedText |
	
	formattedText := self privateFormat: aText.
	self privateStyle: formattedText.
	^formattedText