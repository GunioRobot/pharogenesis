adjustTargetMargin: aFractionalPoint

	| n |

	n _ (aFractionalPoint * 4) rounded.
	myTarget margins: n.
	self showSliderFeedback: n.
