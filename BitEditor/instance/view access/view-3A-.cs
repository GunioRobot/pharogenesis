view: aView

	super view: aView.
	scale _ aView transformation scale.	
	scale _ scale x rounded @ scale y rounded.
	squareForm _ Form extent: scale depth: aView model depth.
	squareForm fillBlack