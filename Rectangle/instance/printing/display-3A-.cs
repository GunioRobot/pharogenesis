display: c 
	"Display the receiver filling it with the given color; by Alan Kay.  Used by his mini painting system, 1/96.
	: fixed so it doesn't always draw a square!"

	| p |
	p _ Pen new.
	p color: c.
	p place: self origin.
	1 to: 2 do:
		[:i | p turn: 90; go: self width.
		p turn: 90; go: self height]