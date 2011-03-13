view: aView

	super view: aView.
	scale := aView transformation scale.	
	scale := scale x rounded @ scale y rounded.
	squareForm := Form extent: scale depth: aView model depth.
	squareForm fillBlack