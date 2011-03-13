chooseColor
	"Wait for the user to select a color and return that color."
	"Details: Waiting for the user is implemented by running the interaction loop until the user has selected a color or dismisse the color picker."

	| w colorPicker |
	w _ self world.
	colorPicker _ self changeColorTarget: nil selector: nil.
	[colorPicker isInWorld] whileTrue: [w doOneCycle].
	^ colorPicker selectedColor
