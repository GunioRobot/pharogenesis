displayLabelBackground: emphasized
	"Clear or emphasize the inner region of the label"
	| r1 r2 r3 c3 c2 c1 |
	emphasized ifFalse:
		["Just clear the label if not emphasized"
		^ Display fill: (self labelDisplayBox insetBy: 2) fillColor: self labelColor].
	r1 := self labelDisplayBox insetBy: 2.
	r2 := r1 insetBy: 0@2.
	r3 := r2 insetBy: 0@3.
	c3 := self labelColor.
	c2 := c3 dansDarker.
	c1 := c2 dansDarker.
	Display fill: r1 fillColor: c1.
	Display fill: r2 fillColor: c2.
	Display fill: r3 fillColor: c3.
 
"	Here is the Mac racing stripe code
	stripes := Bitmap with: (self labelColor pixelWordForDepth: Display depth)
					with: (Form black pixelWordForDepth: Display depth).
	self windowOrigin y even ifTrue: [stripes swap: 1 with: 2].
	Display fill: (self labelDisplayBox insetBy: 3) fillColor: stripes.
"