dropListButtonLabelFor: aDropList
	"Answer the label for the button."
	
	|aMorph|
	aMorph := AlphaImageMorph new image: (self dropListDownArrowForm).
	aMorph enabled: aDropList enabled.
	^aMorph
