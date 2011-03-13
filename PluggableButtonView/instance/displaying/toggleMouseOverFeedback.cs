toggleMouseOverFeedback
	"Complement the label (or a portion of the displayBox if no label is defined) to show that the mouse is over this button. This feedback can be removed by a second call to this method."

	Display reverse: self insetDisplayBox fillColor: Color gray.
	Display reverse: (self insetDisplayBox insetBy: 2) fillColor: Color gray.
