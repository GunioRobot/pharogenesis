modalMVCStyleSelectorWithTitle: title
	"MVC Only! Presents a modal font-style choice menu, answers a TextStyle or nil."
	"TextStyle modalMVCStyleSelectorWithTitle: 'testing'"
	
	| aMenu actualStyles |
	aMenu _ CustomMenu new.
	actualStyles := self actualTextStyles.
	actualStyles keysSortedSafely do: [ :styleName | | style |
		style := actualStyles at: styleName.
		aMenu add: styleName action: style
	].
	^aMenu startUpWithCaption: title.
