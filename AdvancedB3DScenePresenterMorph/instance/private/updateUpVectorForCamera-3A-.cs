updateUpVectorForCamera: aCamera
	| oldUp |
	oldUp := aCamera up.
	aCamera up:
		((aCamera direction cross: oldUp) cross: (aCamera direction))