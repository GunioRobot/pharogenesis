alternateWidgets
	| aHolder widgets |
	aHolder _ self world standardHolder.
	widgets _ OrderedCollection new. 
	#(TextMorph PaintInvokingMorph RecordingControlsMorph) do:
		[:sym | widgets add: ((Smalltalk at: sym) authoringPrototypeIn: aHolder)].

	widgets add: self nextPageButton markAsPartsDonor.
	widgets add: self previousPageButton markAsPartsDonor.

	^ widgets