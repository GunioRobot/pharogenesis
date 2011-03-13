menuItemFor: aService
	[aService isCategory ifTrue: [self menuItemForCategory: aService]
							ifFalse: [self menuItemForAction: aService]] 
		on: Error
		do: [:er | (self confirm: 'menuItemFor: error. debug?') ifTrue: [er signal]]