initialize 
	"ListParagraph initialize"
	| aFont |
	"Allow different line spacing for lists"
	aFont _ Preferences standardListFont.
	ListStyle _ aFont textStyle copy consistOnlyOf: aFont.
	ListStyle gridForFont: 1 withLead: 1