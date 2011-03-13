initialize 
	"ListParagraph initialize"
	| aFont |
	"Allow different line spacing for lists"
	aFont := Preferences standardListFont.
	ListStyle := TextStyle fontArray: { aFont }.
	ListStyle gridForFont: 1 withLead: 1