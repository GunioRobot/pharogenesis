openAndEnter: aProject 
	"Answer an instance of me for the argument, aProject. It is created on 
	the display screen."
	| topView |
	topView := self new model: aProject.
	topView minimumSize: 50 @ 30.
	topView borderWidth: 2.
	topView window: (RealEstateAgent initialFrameFor: topView world: nil).
	ScheduledControllers schedulePassive: topView controller.
	aProject
		enter: false
		revert: false
		saveForRevert: false