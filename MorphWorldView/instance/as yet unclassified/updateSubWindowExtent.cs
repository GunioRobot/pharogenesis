updateSubWindowExtent
	"If this MorphWorldView represents a single Morphic SystemWindow, then update that window to match the size of the WorldView."

	| numMorphs subWindow scrollBarWidth |
	numMorphs := model submorphs size.
	"(Allow for the existence of an extra NewHandleMorph (for resizing).)"
	(numMorphs = 0 or: [numMorphs > 2]) ifTrue: [^self].
	subWindow := model submorphs detect: [:ea | ea respondsTo: #label]
				ifNone: [^self].
	superView label = subWindow label ifFalse: [^self].
	scrollBarWidth := (Preferences valueOfFlag: #inboardScrollbars) 
				ifTrue: [0]
				ifFalse: [14]. 
	subWindow position: model position + (scrollBarWidth @ -16).	"adjust for WiW changes"
	subWindow extent: model extent - (scrollBarWidth @ -16).
	subWindow isActive ifFalse: [subWindow activate]