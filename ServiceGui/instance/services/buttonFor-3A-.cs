buttonFor: aService
	^ aService isCategory ifTrue: [self buttonForCategory: aService]
							ifFalse: [self buttonForAction: aService]