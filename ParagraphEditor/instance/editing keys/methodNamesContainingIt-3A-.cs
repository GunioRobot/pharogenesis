methodNamesContainingIt: characterStream 
	"Browse methods whose selectors containing the selection in their names"

	sensor keyboard.		"flush character"
	self methodNamesContainingIt.
	^ true