setSelection: index
	| newSelection |
	selection = index ifTrue: [^ self].
	newSelection _ (0 max: index) min: frame height // marker height.
	selection > 0 ifTrue: [Display reverse: marker].
	marker _ marker translateBy: 0 @ (newSelection - selection * marker height).
	selection _ newSelection.
	selection > 0 ifTrue: [Display reverse: marker]