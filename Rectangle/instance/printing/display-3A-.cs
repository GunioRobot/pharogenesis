display: c 
	"Display the receiver filling it with the given color; by Alan Kay.  Used by his mini painting system."

	| p |
	p _ Pen new.
	p color: c.
	p place: self origin.
	1 to: 4 do:
		[:i | p turn: 90; go: self width]
	