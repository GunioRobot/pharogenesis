release 
	"Refer to the comment in Object|release."

	scheduledControllers == nil
		ifFalse: 
			[scheduledControllers 
				do: [:controller | (controller isKindOf: Controller)
								ifTrue: [controller view release]
								ifFalse: [controller release]].
			scheduledControllers := nil]