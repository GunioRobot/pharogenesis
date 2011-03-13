allMorphicProjects

	^ self allProjects select: [:p | p world isMorph]