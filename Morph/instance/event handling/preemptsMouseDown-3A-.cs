preemptsMouseDown: evt
	"Return true if this morph wants to handle mouse down events even when the mouse is pressed over a submorph that also wishes to handle mouse down events. Responding true to this message allows a morph to reverse the normal policy that control is given to the inner-most submorph that wants it. This can be used, for example, to allow buttons in a parts bin to be copied when clicked, instead of being activated."

	^ self isPartsDonor
