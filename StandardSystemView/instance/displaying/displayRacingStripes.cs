displayRacingStripes
	"Display Racing Stripes in the label"
	| labelDisplayBox stripes top bottom left box right |
	labelDisplayBox := self labelDisplayBox.
	top := labelDisplayBox top + 3.
	bottom := labelDisplayBox bottom - 3.
	stripes := Bitmap with: (Display pixelWordFor: self labelColor)
			with: (Display pixelWordFor: Color black).
	top even ifFalse: [stripes swap: 1 with: 2].

	left := labelDisplayBox left + 3.

	box := self closeBoxFrame.
	right := box left - 2.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
	left := box right + 2.

	box := self labelTextRegion.
	right := box left - 3.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
	left := box right + 2.

	box := self growBoxFrame.
	right := box left - 2.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
	left := box right + 2.

	right := labelDisplayBox right - 3.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
