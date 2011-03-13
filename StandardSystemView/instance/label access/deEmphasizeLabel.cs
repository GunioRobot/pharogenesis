deEmphasizeLabel
	"Clear the racing stripes."
	| labelDisplayBox top bottom left box right |
	labelDisplayBox _ self labelDisplayBox.
	top _ labelDisplayBox top + 3.
	bottom _ labelDisplayBox bottom - 3.

	left _ labelDisplayBox left + 3.
	box _ self labelTextRegion.
	right _ box left - 3.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: self labelColor.

	left _ box right + 2.
	right _ labelDisplayBox right - 3.
	Display fill: (Rectangle left: left right: right top: top bottom: bottom)
			fillColor: self labelColor