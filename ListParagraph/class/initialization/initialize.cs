initialize 
	"ListParagraph initialize"
	| aFont |
	"Allow different line spacing for lists"
	aFont _ Preferences standardListFont.
	ListStyle _ TextStyle fontArray: { aFont }.
	ListStyle gridForFont: 1 withLead: 1