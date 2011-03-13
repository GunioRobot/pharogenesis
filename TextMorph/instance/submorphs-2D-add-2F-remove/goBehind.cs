goBehind
	"We need to save the container, as it knows about fill and run-around"
	| cont |
	container ifNil: [^ super goBehind].
	self releaseParagraph.  "Cause recomposition"
	cont _ container.  "Save the container"
	super goBehind.  "This will change owner, nilling the container"
	container _ cont.  "Restore the container"
	self changed