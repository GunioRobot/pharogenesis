accept
	"the user press the [accept] button"
	serverNameWidget hasUnacceptedEdits
		ifTrue: [serverNameWidget accept].
	portWidget hasUnacceptedEdits
		ifTrue: [portWidget accept].
	""
	self applyChanges.
	""
	self delete