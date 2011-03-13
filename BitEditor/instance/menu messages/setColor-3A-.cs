setColor: aColor 
	"Set the color that the next edited dots of the model to be the argument,  
	aSymbol. aSymbol can be any color changing message understood by a  
	Form, such as white or black."

	color := aColor pixelValueForDepth: Display depth.
	squareForm fillColor: aColor.
	self changed: #getCurrentColor