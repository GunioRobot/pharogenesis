removeAll: projects
	"Project removeAll: (Project allSubInstances copyWithout: Project current)"

	AllProjects := nil.
	Smalltalk garbageCollect.

	projects do: [:project |
		Project deletingProject: project.
		StandardScriptingSystem removePlayersIn: project].

	Smalltalk garbageCollect.
	Smalltalk garbageCollect.
