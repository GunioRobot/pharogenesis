indicatorReverse
	"Complement the label (or a portion of the displayBox if no label is 
	defined)."

	Display reverse: self insetDisplayBox fillColor: Color gray.
	Display reverse: (self insetDisplayBox insetBy: 2) fillColor: Color gray