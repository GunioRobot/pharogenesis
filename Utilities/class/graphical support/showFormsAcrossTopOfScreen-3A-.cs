showFormsAcrossTopOfScreen: aFormList
	"Display the given array of forms across the top of the screen, wrapping to subsequent lines if needed.    Useful for example for looking at sets of rotations and animations.  6/10/96 sw"

	| position maxHeight screenBox ceiling |

	position _ 20.
	maxHeight _ 0.
	ceiling _ 0.
	screenBox _ Display boundingBox.
	aFormList do:
		[:elem | elem displayAt: (position @ ceiling).
			maxHeight _ maxHeight max: elem boundingBox height.
			position _ position + elem boundingBox width + 5.
			position > (screenBox right - 100) ifTrue:
				[position _ 20.
				ceiling _ ceiling + maxHeight + 10.
				maxHeight _ 0]]