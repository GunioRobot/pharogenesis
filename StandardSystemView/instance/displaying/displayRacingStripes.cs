displayRacingStripes
	"Display Racing Stripes in the label"
	| labelDisplayBox stripes top bottom left box right |
	labelDisplayBox _ self labelDisplayBox.
	top _ labelDisplayBox top + 3.
	bottom _ labelDisplayBox bottom - 3.
	stripes _ Bitmap with: (self labelColor pixelWordForDepth: Display depth)
			with: (Color black pixelWordForDepth: Display depth).
	top even ifFalse: [stripes swap: 1 with: 2].

	left _ labelDisplayBox left + 3.

	box _ self closeBoxFrame.
	right _ box left - 2.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
	left _ box right + 2.

	box _ self labelTextRegion.
	right _ box left - 3.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
	left _ box right + 2.

	box _ self growBoxFrame.
	right _ box left - 2.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
	left _ box right + 2.

	right _ labelDisplayBox right - 3.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: stripes.
