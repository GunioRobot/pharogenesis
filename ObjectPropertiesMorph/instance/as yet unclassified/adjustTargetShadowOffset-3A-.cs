adjustTargetShadowOffset: aFractionalPoint

	| n |

	myTarget changed; layoutChanged.
	myTarget shadowOffset: (n _ (aFractionalPoint * 4) rounded).
	self showSliderFeedback: n.
	myTarget changed; layoutChanged.
