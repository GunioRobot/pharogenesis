updateGray
	(screenController view model isMemberOf: InfiniteForm)
		ifTrue: [screenController view model: (InfiniteForm with: Color gray)]