changeTextFontDialog
	"Present a dialog which allows the user to select a font, and if one is chosen, apply it to the current selection.	If there is no selection, or the selection is empty, apply it to the whole morph."
		
	"?? Should the dialog allow the user to select a bold/italic/black font.
	Or just the most regular member of a Font Family?"
	| curFont startIndex chooser newFont |
	startIndex := self startIndex.
	"stopIndex := self stopIndex-1 min: paragraph text size."
	curFont := (paragraph text fontAt: startIndex withStyle: paragraph textStyle).
	(curFont isKindOf: LogicalFont)
		ifTrue:[
			curFont := curFont copy.
			((paragraph text emphasisAt: startIndex) anyMask: 1) ifTrue:[curFont forceBold].
			((paragraph text emphasisAt: startIndex) anyMask: 2) ifTrue:[curFont forceItalicOrOblique].
			curFont clearRealFont].
	chooser := morph openModal: (
		Cursor wait showWhile: [ 
			FontChooser 
				windowTitle: 'Change the selected text''s font to...' translated
				for: self 
				setSelector: #changeSelectionFontTo:
				getSelector: curFont]).
	newFont := chooser result.
	newFont ifNotNil:[self changeSelectionFontTo: newFont].