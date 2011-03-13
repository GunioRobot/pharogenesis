indicateModalChild
	"Make the user aware that this is the topmost modal child
	by flashing."

	(self isMinimized and: [self isTaskbarPresent])
		ifTrue: [self worldTaskbar ifNotNilDo: [:tb |
					tb indicateModalChildForMorph: self]]
		ifFalse: [self flash]