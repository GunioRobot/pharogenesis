controlLoop 
	sensor leftShiftDown ifTrue:
		["Hold shift down when activating a Morphic window to take stats"
		(self confirm: 'The shift key was down;
do you really want to spy on Morphic?') ifTrue:
			[^ MessageTally spyOn: [super controlLoop. Cursor normal show]]].

	"Overridden to keep control active when the hand drags something out of the view"
	[self viewHasCursor or:
		[Sensor anyButtonPressed or: [model primaryHand submorphs size > 0]]]
		whileTrue:
			[self controlActivity. Processor yield].
