edit: aText label: labelString accept: anAction
	"Open an editor on the given string/text"
	| window holder text |
	holder := StringHolder new.
	holder contents: aText.
	text := PluggableTextMorphPlus 
		on: holder 
		text: #contents 
		accept: #acceptContents: 
		readSelection: nil 
		menu: nil.
	text acceptAction: anAction.
	window := SystemWindow new.
	labelString ifNotNil:[window setLabel: labelString].
	window addMorph: text frame: (0@0 extent: 1@1).
	window paneColor: Color gray.
	window openInWorld.
