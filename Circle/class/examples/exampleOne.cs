exampleOne 
	"Click any button somewhere on the screen. The point will be the center
	of the circcle of radius 150."

	| aCircle aForm |
	aForm _ Form extent: 1@30.
	aForm fillBlack.
	aCircle _ Circle new.
	aCircle form: aForm.
	aCircle radius: 150.
	aCircle center: Sensor waitButton.
	aCircle displayOn: Display
	
	"Circle exampleOne"