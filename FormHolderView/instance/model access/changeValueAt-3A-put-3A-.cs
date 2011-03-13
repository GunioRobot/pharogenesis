changeValueAt: location put: anInteger 
	"Refer to the comment in FormView|changeValueAt:put:."

	displayedForm pixelValueAt: location put: anInteger.
	displayedForm changed: self