show
	"Open the tool returning the window."
	
	modal := false.
	Smalltalk at: #ToolBuilder ifPresent: [:tb | ^tb open: self].
	^self window openInWorldExtent: self defaultExtent; yourself