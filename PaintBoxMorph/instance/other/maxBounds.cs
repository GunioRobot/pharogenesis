maxBounds
	| rr |
	"fullBounds if all flop-out parts of the paintBox were showing."

	rr _ bounds merge: colorMemory bounds.
	rr _ rr merge: (self submorphNamed: 'stamps') bounds.
	rr _ rr origin corner: rr corner + (0@ (self submorphNamed: 'shapes') height 
				+ 10 "what is showing of (self submorphNamed: #toggleShapes) height").
	^ rr