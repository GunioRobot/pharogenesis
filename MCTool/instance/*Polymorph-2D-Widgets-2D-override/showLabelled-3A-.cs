showLabelled: labelString
	"Use ToolBuilder if available."
	
	modal := false.
	self label: labelString.
	Smalltalk at: #ToolBuilder ifPresent: [:tb | tb open: self. ^ self].
	^(self window)
		openInWorldExtent: self defaultExtent;
		yourself