startUpYellowButtonMenu
	| object |
	object _ model object.
	^ (model selectionUnmodifiable or: [object isKindOf: Array])
		ifTrue:
			[super startUpYellowButtonMenu]
		ifFalse:
			[yellowButtonMenu startUpWithCaption: (model selectedSlotName, '(', model selection class name, ')')]