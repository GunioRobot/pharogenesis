adjustTargetBorderWidth: aFractionalPoint

	| n |

	myTarget borderWidth: (n _ (aFractionalPoint x * 10) rounded max: 0).
	self showSliderFeedback: n.