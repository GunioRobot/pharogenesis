getWorld
	^ world
		ifNil: [world := Project newMorphic world]