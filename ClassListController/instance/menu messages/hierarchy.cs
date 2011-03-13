hierarchy
	"Request that the receiver's view display the class hierarchy (super- and 
	subclasses) of the selected class so that it can be edited."

	self controlTerminate.
	model hierarchy.
	self controlInitialize