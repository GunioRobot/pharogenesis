where
	"Select the expression whose evaluation was interrupted."

	selectingPC _ true.
	self contextStackIndex: contextStackIndex oldContextWas: self selectedContext
