classListKey: aChar from: view
	
	"Overridden to obviate spurious StringHolder processing of $s for findClass"
	^ self messageListKey: aChar from: view