red: r green: g blue: b alpha: a
	"Create an initialize a color vector."

	| newColor |
	newColor _ B3DColor4 new.

	newColor red: r.
	newColor green: g.
	newColor blue: b.
	newColor alpha: a.

	^ newColor.
