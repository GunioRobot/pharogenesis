addMorph: aMorph fullFrame: aLayoutFrame

	super addMorph: aMorph fullFrame: aLayoutFrame.

	paneMorphs _ paneMorphs copyReplaceFrom: 1 to: 0 with: (Array with: aMorph).
	Preferences alternativeWindowLook
		ifFalse:
			[aMorph borderWidth: 1.
			aMorph color: self paneColor]
		ifTrue:
		    [(aMorph isKindOf: ImageMorph) ifFalse:[
			aMorph adoptPaneColor: self paneColor.
			aMorph borderWidth: 2; borderColor: #inset; color: Color transparent]].
	Preferences scrollBarsOnRight	"reorder panes so flop-out right-side scrollbar is visible"
		ifTrue: [self addMorphBack: aMorph]