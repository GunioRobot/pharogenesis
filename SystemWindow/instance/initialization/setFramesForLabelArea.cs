setFramesForLabelArea

	"an aid to converting old instances, but then I found convertAlignment"

	| frame |

	frame _ LayoutFrame new.
	frame leftFraction: 0.5; topFraction: 0; leftOffset: label width negated // 2.
	label layoutFrame: frame.

	frame _ LayoutFrame new.
	frame rightFraction: 1; topFraction: 0; rightOffset: -1; topOffset: 1.
	collapseBox layoutFrame: frame.

	frame _ LayoutFrame new.
	frame leftFraction: 0; topFraction: 0; rightFraction: 1;
			leftOffset: 1; topOffset: 1; rightOffset: -1.
	stripes first layoutFrame: frame.
	stripes first height: self labelHeight - 2.
	stripes first hResizing: #spaceFill.

	frame _ LayoutFrame new.
	frame leftFraction: 0; topFraction: 0; rightFraction: 1;
			leftOffset: 3; topOffset: 3; rightOffset: -3.
	stripes last layoutFrame: frame.
	stripes last height: self labelHeight - 6.
	stripes last hResizing: #spaceFill.

	frame _ LayoutFrame new.
	frame leftFraction: 0; topFraction: 0; rightFraction: 1;
			topOffset: self labelHeight negated.
	labelArea layoutFrame: frame.

