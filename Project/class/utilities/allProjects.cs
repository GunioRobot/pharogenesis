allProjects

	^ self allSubInstances select: [:p | p name notNil]