labelDisplayBox
	"Answer the rectangle that borders the visible parts of the receiver's label 
	on the display screen."

	^ labelFrame region
		align: labelFrame topLeft
		with: self windowOrigin