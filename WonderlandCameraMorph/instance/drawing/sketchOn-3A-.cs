sketchOn: aCanvas
	| vtx prev next |
	vtx _ self outline.
	vtx reset.
	vtx atEnd ifTrue:[^self].
	prev _ vtx next.
	[vtx atEnd] whileFalse: [
		next _ vtx next.
		aCanvas line: prev to: next width: 5 color: Color red.
		prev _ next]