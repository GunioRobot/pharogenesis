partsAndTypesForViewer
	"Return an array of part names and part types for use in a viewer on the receiver"
	^ super partsAndTypesForViewer, #(
		(borderWidth 		number)
		(borderColor			color)
	)
