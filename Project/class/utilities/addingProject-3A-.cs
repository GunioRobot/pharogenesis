addingProject: newProject

	(self allProjects includes: newProject) ifTrue: [^self].
	AllProjects _ self allProjects copyWith: newProject.