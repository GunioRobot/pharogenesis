deletingProject: aProject
	"My project is being deleted.  Delete me as well."

	self flag: #bob.		"zapping projects"


	project == aProject ifTrue: [
		self owner isSystemWindow ifTrue: [self owner model: nil; delete].
		self delete].