getMatrixFromRoot
	"Returns the composite transformation matrix from the root down to this instance"

	^ (myParent getMatrixFromRoot) composeWith: composite.
