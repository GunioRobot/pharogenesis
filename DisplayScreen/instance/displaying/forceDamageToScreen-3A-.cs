forceDamageToScreen: allDamage
	"Force all the damage rects to the screen."
	| rectList excluded remaining regions |
	rectList _ allDamage.
	"Note: Reset extra regions at the beginning to prevent repeated errors"
	regions _ extraRegions.
	extraRegions _ nil.
	regions ifNotNil:[
		"exclude extra regions"
		regions do:[:drawerAndRect|
			excluded _ drawerAndRect at: 2.
			remaining _ WriteStream on: #().
			rectList do:[:r|
				remaining nextPutAll:(r areasOutside: excluded)].
			rectList _ remaining contents].
	].
	rectList do:[:r| self forceToScreen: r].
	regions ifNotNil:[
		"Have the drawers paint what is needed"
		regions do:[:drawerAndRect| (drawerAndRect at: 1) forceToScreen].
	].