deletingProject: aProject
	"Clear my previousProject link if it points at the given Project, which is being deleted."

	previousProject == aProject
		ifTrue: [previousProject _ nil].
	nextProject == aProject
		ifTrue:	[nextProject _ nil]
