addTextualScript: aBrowser
	"Put a message browser right into the header alignment morph"

	| window aMorph codePane |
	submorphs last class == PluggableTextMorph ifTrue: [^ self].
	window _ self.
	aMorph _ PluggableListMorph on: aBrowser list: #messageListSingleton
			selected: #indexIsOne changeSelected: #indexIsOne:
			menu: #messageListMenu:shifted:.
	aMorph bounds: (window topLeft extent: 200@12).	"will get moved"
	window addMorphBack: aMorph.
	aMorph borderWidth: 1;
		color: (Color colorFrom: aBrowser defaultBackgroundColor).

	codePane _ PluggableTextMorph on: aBrowser text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
	"editString ifNotNil: [codePane editString: editString.
					codePane hasUnacceptedEdits: true]."
	codePane bounds: (window topLeft extent: 200@120).	"will get moved"
	window addMorphBack: codePane.
	codePane borderWidth: 1; retractableOrNot; "make it stay"
		color: (Color perform: aBrowser defaultBackgroundColor).


"	self addMorph: aMorph.
	aMorph borderWidth: 1;
		color: (Color perform: aBrowser defaultBackgroundColor);
		bounds: 
"