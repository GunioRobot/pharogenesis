wrappedInWindowWithTitle: aTitle
	| aWindow |
	aWindow _ (SystemWindow labelled: aTitle) model: Model new.
	aWindow addMorph: self frame: (0@0 extent: 1@1).
	aWindow extent: self extent + (2 @ 18).
	^ aWindow