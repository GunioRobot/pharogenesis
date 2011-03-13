redoTarget: target selector: selector arguments: arguments
	"Give target morph a chance to refine its undo operation"

	target refineRedoTarget: target selector: selector arguments: arguments in:
		[:rTarget :rSelector :rArguments |
		redoTarget _ rTarget.
		redoSelector _ rSelector.
		redoArguments _ rArguments]