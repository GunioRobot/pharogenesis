expungeProject
	(self confirm: ('Do you really want to delete {1}
and all its content?' translated format: {project name}))
		ifFalse: [^ self].
	owner isSystemWindow
		ifTrue: [owner model: nil;
				 delete].
	ProjectHistory forget: project.
	Project deletingProject: project