updateRepositories
	"This code makes sure that all packages have a repository assigned, including the dependencies."

	repositories keysAndValuesDo: [ :version :collection |
		collection do: [ :repository |
			version workingCopy repositoryGroup
				addRepository: repository ] ]