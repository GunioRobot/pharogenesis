boxExtent
	"answer the extent to use in all the buttons. 
	 
	the label height is used to be proportional to the fonts preferences"
	^ (Preferences alternativeWindowBoxesLook
		ifTrue: [18 @ 18]
		ifFalse: [14 @ 14])
		max: label height @ label height 