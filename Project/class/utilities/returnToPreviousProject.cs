returnToPreviousProject
	"Return to the project from which this project was entered. Do nothing if the current project has no link to its previous project."

	| prevProj |
	prevProj _ CurrentProject previousProject.
	prevProj ifNotNil: [prevProj enter: true].
