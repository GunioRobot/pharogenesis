setTransformation: aTransformation 
	"Set the View's local transformation to aTransformation, unlock the View 
	(see View|unlock), and set the viewport to undefined (this forces it to be 
	recomputed when needed). Should be used instead of setting the 
	transformation directly."

	transformation := aTransformation.
	self unlock.
	viewport := nil