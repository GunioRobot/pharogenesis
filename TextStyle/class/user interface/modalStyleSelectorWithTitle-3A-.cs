modalStyleSelectorWithTitle: title
	"Presents a modal font-style choice menu, answers a TextStyle or nil."
	"TextStyle modalStyleSelectorWithTitle: 'testing'"
	
	| menu actualStyles |
	Smalltalk isMorphic ifFalse: [ ^self modalMVCStyleSelectorWithTitle: title ].

	menu _ MenuMorph entitled: title.
	actualStyles := self actualTextStyles.
	actualStyles keysSortedSafely do: [ :styleName | | style |
		style := actualStyles at: styleName.
		menu add: styleName target: menu selector: #modalSelection: argument: style.
		menu lastItem font: (style fontOfSize: 18)
	].
	^menu invokeModal.
