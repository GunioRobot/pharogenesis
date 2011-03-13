packageDescriptions
	^ self sortedPackages collect: [:p | self packageOneLineDescription: p]