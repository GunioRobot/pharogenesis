title: aString
	"Set the window title."
	
	super title: aString.
	label fitContents.
	self minimumExtent: ((label width + 20 min: (Display width // 2))@ self minimumExtent y)