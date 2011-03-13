deletingProject: aProject
	"My project is being deleted.  Delete me as well."

	self flag: #bob.		"zapping projects"


	project == aProject ifTrue: [self delete].