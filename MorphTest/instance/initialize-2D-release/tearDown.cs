tearDown
	morph delete.
	world
		ifNotNil: [Project deletingProject: world project]