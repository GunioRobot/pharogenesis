layoutChanged
	"Process the changed layout and then change the aspect ratio of the camera to match"

	super layoutChanged.

	myCamera setAspectRatio: ((self width) / (self height)) asFloat.
