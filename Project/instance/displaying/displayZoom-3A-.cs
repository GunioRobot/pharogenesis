displayZoom: entering
	"Show the project transition when entering a new project"
	| newDisplay vanishingPoint |
	"Play the flash transition if any."
	self projectParameters at: #flashTransition ifPresent:[:dict|
		dict at: CurrentProject ifPresent:[:player| ^player playProjectTransitionFrom: CurrentProject to: self entering: entering]].
	"Show animated zoom to new display"
	newDisplay _ self imageForm.
	entering
		ifTrue: [vanishingPoint _ Sensor cursorPoint]
		ifFalse: [vanishingPoint _ self viewLocFor: CurrentProject].
	Display zoomIn: entering orOutTo: newDisplay at: 0@0
			vanishingPoint: vanishingPoint.