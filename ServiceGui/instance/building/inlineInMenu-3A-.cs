inlineInMenu: aMenu 
	^ self class inlineServices
		ifTrue: [self inlineInMenu: aMenu for: service]
		ifFalse: [aMenu]