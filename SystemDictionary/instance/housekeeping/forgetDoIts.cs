forgetDoIts

	Smalltalk allBehaviorsDo: "get rid of old DoIt methods"
			[:cl | cl removeSelector: #DoIt; removeSelector: #DoItIn:]

	"Smalltalk forgetDoIts"