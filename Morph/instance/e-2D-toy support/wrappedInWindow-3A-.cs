wrappedInWindow: aSystemWindow
	| aWindow |
	aWindow _ aSystemWindow model: Model new.
	aWindow addMorph: self frame: (0@0 extent: 1@1).
	aWindow extent: self extent.
	^ aWindow