addAlansAnchorFor: aMorph

	| ed attribute selRects |

	self removeAlansAnchorFor: aMorph.
	ed _ self editor.
	attribute _ TextAnchorPlus new anchoredMorph: aMorph.
	ed replaceSelectionWith: (ed selection addAttribute: attribute).
	selRects _ self paragraph selectionRects.
	selRects isEmpty ifFalse: [
		aMorph top: selRects first top
	].
	self releaseParagraphReally.
	self layoutChanged.

