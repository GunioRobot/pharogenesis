updateSubWindowExtent
	"If this MorphWorldView represents a single Morphic SystemWindow, then update that window to match the size of the WorldView."

	| numMorphs subWindow scrollBarWidth |
	numMorphs _ model submorphs size.
	"(Allow for the existence of an extra NewHandleMorph (for resizing).)"
	(numMorphs = 0 or: [numMorphs > 2]) ifTrue: [^ self].
	subWindow _ model submorphs
					detect: [:ea | ea respondsTo: #label]
					ifNone: [^ self].
	superView label = subWindow label ifFalse: [^ self].
	(Preferences valueOfFlag: #inboardScrollbars)
		ifTrue: [scrollBarWidth _ 0]
		ifFalse: [scrollBarWidth _ 14].
	subWindow position: model position + (scrollBarWidth@-16).	"adjust for WiW changes"
	subWindow extent: model extent - (scrollBarWidth@-16).
	subWindow isActive ifFalse: [subWindow activate].