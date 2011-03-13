invokeFrom: otherProject
	"Revoke the changes in force for this project, and then invoke those in force for otherProject.  This method shortens the process to the shortest path up then down through the isolation layers."

	| pathUp pathDown |
	pathUp := otherProject layersToTop.  "Full paths to top"
	pathDown := self layersToTop.

	"Shorten paths to nearest common ancestor"
	[pathUp isEmpty not
		and: [pathDown isEmpty not
		and: [pathUp last == pathDown last]]]
		whileTrue: [pathUp removeLast.  pathDown removeLast].

	"Now revoke changes up from otherProject and invoke down to self."
	pathUp do: [:p | p revoke].
	pathDown reverseDo: [:p | p invoke].
