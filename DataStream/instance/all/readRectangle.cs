readRectangle
    "Read a compact Rectangle.  Rectangles with values outside +/- 2047 were stored as normal objects (type=9).  They will not come here.  17:22 tk"

	"Encoding is four 12-bit signed numbers.  48 bits in next 6 bytes.  17:24 tk"
	| acc left top right bottom |
	acc _ byteStream nextNumber: 3.
	left _ acc bitShift: -12.
	(left bitAnd: 16r800) ~= 0 ifTrue: [left _ left - 16r1000].	"sign"
	top _ acc bitAnd: 16rFFF.
	(top bitAnd: 16r800) ~= 0 ifTrue: [top _ top - 16r1000].	"sign"

	acc _ byteStream nextNumber: 3.
	right _ acc bitShift: -12.
	(right bitAnd: 16r800) ~= 0 ifTrue: [right _ right - 16r1000].	"sign"
	bottom _ acc bitAnd: 16rFFF.
	(bottom bitAnd: 16r800) ~= 0 ifTrue: [bottom _ bottom - 16r1000].	"sign"
	
    ^ Rectangle left: left right: right top: top bottom: bottom
