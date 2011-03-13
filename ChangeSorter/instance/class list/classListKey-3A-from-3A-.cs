classListKey: aChar from: view
	"Overridden to obviate spurious StringHolder processing of $f for findClass"

	^ self messageListKey: aChar from: view