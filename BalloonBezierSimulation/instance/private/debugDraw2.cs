debugDraw2
	| canvas last max t next |
	canvas _ Display getCanvas.
	max _ 100.
	last _ nil.
	0 to: max do:[:i|
		t _ i asFloat / max asFloat.
		next _ self valueAt: t.
		last ifNotNil:[
			canvas line: last to: next rounded width: 2 color: Color blue.
		].
		last _ next rounded.
	].