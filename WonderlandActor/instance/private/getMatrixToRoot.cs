getMatrixToRoot
	"Returns the composite transformation matrix from this instance up to the root"

	^ ((myParent getMatrixFromRoot) composeWith: composite) inverseTransformation.
