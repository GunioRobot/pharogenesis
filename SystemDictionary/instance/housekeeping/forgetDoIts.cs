forgetDoIts	
	"Smalltalk forgetDoIts"
	 "get rid of old DoIt methods"

	self systemNavigation allBehaviorsDo:
		[:cl | cl forgetDoIts]

