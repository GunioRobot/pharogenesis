controlLoop 
	| outAndMouseUp |
	sensor leftShiftDown ifTrue:
		["Hold shift down when activating a Morphic window to take stats"
		(self confirm: 'The shift key was down;
do you really want to spy on Morphic?') ifTrue:
			[^ MessageTally spyOn: [super controlLoop. Cursor normal show]]].

	"Overridden to keep control active when mouse leaves the view..."
	outAndMouseUp _ false.
	[outAndMouseUp and: [Sensor anyButtonPressed]]
		whileFalse:
		[self controlActivity. Processor yield.
		self viewHasCursor
			ifTrue: [outAndMouseUp _ false]
			ifFalse: [outAndMouseUp _ outAndMouseUp | Sensor noButtonPressed]]
