triArea: a with: b with: c
	"Returns twice the area of the oriented triangle (a, b, c), i.e., the
	area is positive if the triangle is oriented counterclockwise."
	^((b x - a x) * (c y - a y)) - ((b y - a y) * (c x - a x))