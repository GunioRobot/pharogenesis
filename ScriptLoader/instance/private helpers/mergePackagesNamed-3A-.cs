mergePackagesNamed: names
	| vm  |
	repository _ MCHttpRepository
                location: 'http://source.squeakfoundation.org/39a'
                user: ''
                password: ''.

	vm _ MCVersionMerger new.
	names
		do: [:fn | vm addVersion: (repository loadVersionFromFileNamed: fn)]
		displayingProgress: 'Adding versions...'.

	[vm merge]
		on: MCMergeResolutionRequest do: [:request |
			request merger conflicts isEmpty
				ifTrue: [request resume: true]
				ifFalse: [request pass]]