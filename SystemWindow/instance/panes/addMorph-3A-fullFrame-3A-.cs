addMorph: aMorph fullFrame: aLayoutFrame

	super addMorph: aMorph fullFrame: aLayoutFrame.

	paneMorphs _ paneMorphs copyReplaceFrom: 1 to: 0 with: (Array with: aMorph).
	aMorph borderWidth: 1.
	aMorph color: self paneColor.
