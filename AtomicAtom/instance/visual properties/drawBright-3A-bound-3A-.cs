drawBright: aCanvas bound: aBound 
	"Circles representing light"
	| selectedColor newBound |
	selectedColor _ self defaultColor.
	newBound _ aBound insetBy: 2.
	1
		to: 4
		do: [:index | 
			selectedColor _ selectedColor alphaMixed: 0.77 with: Color white.
			aCanvas fillOval: newBound color: selectedColor.
			newBound _ (newBound insetBy: 2)
						translateBy: -1].
	^ aBound