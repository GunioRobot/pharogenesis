deletingProject: aProject
	"My project is being deleted.  Delete me as well."

	project == aProject ifTrue: [self delete].