slideIndexBy: delta andMoveTopTo: newTop
	"Relocate my character indices and y-values.
	Used to slide constant text up or down in the wake of a text replacement."

	firstIndex _ firstIndex + delta.
	lastIndex _ lastIndex + delta.
	bottom _ bottom + (newTop - top).
	top _ newTop.
