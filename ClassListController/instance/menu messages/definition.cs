definition
	"Request that the receiver's view display the definition of the selected 
	class so that it can be edited."

	self controlTerminate.
	model editClass.
	self controlInitialize