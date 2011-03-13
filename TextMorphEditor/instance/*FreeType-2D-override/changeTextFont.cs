changeTextFont
	"Present a menu of available fonts, and if one is chosen, apply it to the current selection.
	If there is no selection, or the selection is empty, apply it to the whole morph."
	| useDialog |
	useDialog := true. "make this false to use a menu"
	^useDialog 
		ifTrue:[self changeTextFontDialog]
		ifFalse:[self changeTextFontAlphabeticalMenu]