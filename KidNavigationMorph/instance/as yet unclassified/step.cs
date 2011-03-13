step

	super step.
	PreExistingProjects ifNil: [PreExistingProjects _ WeakArray withAll: Project allProjects].