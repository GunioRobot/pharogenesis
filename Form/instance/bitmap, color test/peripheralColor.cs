peripheralColor
	"Return most common peripheral color,
	as sampled at 4 corners and 3 edges
	(this is so that the corners of round rectangles
	will win over the edges)"
	| perim samples |
	perim _ self boundingBox insetBy: (0@0 corner: 1@1).
	samples _ #(topLeft topCenter topRight rightCenter bottomRight bottomLeft leftCenter) collect:
		[:locName | self pixelValueAt: (perim perform: locName)].
	^ samples asBag sortedElements first key