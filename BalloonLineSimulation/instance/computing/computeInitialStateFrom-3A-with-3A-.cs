computeInitialStateFrom: source with: aTransformation
	"Compute the initial state in the receiver."
	start _ (aTransformation localPointToGlobal: source start) asIntegerPoint.
	end _ (aTransformation localPointToGlobal: source end) asIntegerPoint.