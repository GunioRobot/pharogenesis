release
	"Break the cycle between the Controller and its view. It is usually not 
	necessary to send release provided the Controller's view has been properly 
	released independently."

	super release.
	form _ nil