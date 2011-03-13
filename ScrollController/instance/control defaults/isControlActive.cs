isControlActive 
	| fullArea |
	view isNil ifTrue: [^ false].
	fullArea _ view insetDisplayBox merge: scrollBar.
	^ fullArea containsPoint: sensor cursorPoint