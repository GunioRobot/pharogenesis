show
	"Show my samples in a GraphMorph."

	| g m |
	recorder pause.
	g _ GraphMorph new extent: 500@150; data: recorder condensedSamples.

	m _ StringMorph new contents: 'Index:'.
	g addMorph: (m position: 5@5).
	m _ UpdatingStringMorph new
		target: g; getSelector: #cursor; putSelector: #cursor:; step.
	g addMorph: (m position: 45@5).

	m _ StringMorph new contents: 'Value:'.
	g addMorph: (m position: 5@20).
	m _ UpdatingStringMorph new
		target: g; getSelector: #valueAtCursor; putSelector: #valueAtCursor:; step.
	g addMorph: (m position: 45@20).

	self world hands first attachMorph: g.
