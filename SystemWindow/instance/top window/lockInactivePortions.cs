lockInactivePortions
	"Make me unable to respond to mouse and keyboard.  Control boxes remain active, except in novice mode"

	self submorphsDo: [:m | m == labelArea ifFalse: [m lock]].
	labelArea ifNotNil: 
			[labelArea submorphsDo: 
					[:m | 
					(m == closeBox or: [m == collapseBox]) 
						ifTrue: [m lock]]]