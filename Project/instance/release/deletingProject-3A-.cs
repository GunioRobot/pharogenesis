deletingProject: aProject
	"Clear my previousProject link if it points at the given Project, which is being deleted."

	self flag: #bob.		"zapping projects"

	parentProject == aProject ifTrue: [
		parentProject _ parentProject parent
	].
	previousProject == aProject
		ifTrue: [previousProject _ nil].
	nextProject == aProject
		ifTrue:	[nextProject _ nil]
