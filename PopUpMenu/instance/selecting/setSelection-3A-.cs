setSelection: index
	| lineHeight newSelection |
	lineHeight _ font height.
	newSelection _ (0 max: index) min: frame height // lineHeight.
	marker _ marker translateBy:
		 0 @ (lineHeight * (newSelection - selection)).
	selection _ newSelection