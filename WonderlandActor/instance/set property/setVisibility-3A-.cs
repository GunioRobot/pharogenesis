setVisibility: newVisibility
	"Sets the current object's visibility"

	^ (self setVisibility: newVisibility duration: 1.0
			style: gently).
