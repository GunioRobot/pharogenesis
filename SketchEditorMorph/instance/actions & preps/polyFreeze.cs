polyFreeze
	"A live polygon is on the painting.  Draw it into the painting and
delete it."

	| poly |
	(poly _ self valueOfProperty: #polygon) ifNil: [^ self].
	poly drawOn: formCanvas.
	poly delete.
	self setProperty: #polygon toValue: nil.