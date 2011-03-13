requestor
	"returns the focused window's requestor"

	"SystemWindow focusedWindow ifNotNilDo: [:w | ^ w requestor]."

	"triggers an infinite loop"

	^ Requestor default