extent: aPoint
	"Contrain extent to be square."

	| d |
	d _ aPoint x min: aPoint y.
	super extent: d@d.
