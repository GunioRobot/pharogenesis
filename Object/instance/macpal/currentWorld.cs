currentWorld
	"Answer a morphic world that is the current UI focus.
		If in an embedded world, it's that world.
		If in a morphic project, it's that project's world.  
		If in an mvc project, it is the topmost morphic-mvc-window's worldMorph. 
		If in an mvc project that has no morphic-mvc-windows, then it's just some existing worldmorph instance.
		If in an mvc project in a Squeak that has NO WorldMorph instances, one is created.

	This method will never return nil, it will always return its best effort at returning a relevant world morph, but if need be -- if there are no worlds anywhere, it will create a new one."

	| aView aSubview |
	ActiveWorld ifNotNil:[^ActiveWorld].
	World ifNotNil:[^World].
	aView _ ScheduledControllers controllerSatisfying:
		[:ctrl | (aSubview _ ctrl view firstSubView) notNil and:
			[aSubview model isMorph and: [aSubview model isWorldMorph]]].
	^aView
		ifNotNil:
			[aSubview model]
		ifNil:
			[MVCWiWPasteUpMorph newWorldForProject: nil].