classCommentsContainingIt
	"Open a browser class comments which contain the current selection somewhere in them."

	self lineSelectAndEmptyCheck: [^ self].
	self terminateAndInitializeAround: [
		self systemNavigation browseClassCommentsWithString: self selection string]