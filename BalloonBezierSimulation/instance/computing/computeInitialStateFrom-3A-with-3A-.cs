computeInitialStateFrom: source with: transformation
	"Compute the initial state in the receiver."
	start _ (transformation localPointToGlobal: source start) asIntegerPoint.
	end _ (transformation localPointToGlobal: source end) asIntegerPoint.
	via _ (transformation localPointToGlobal: source via) asIntegerPoint.