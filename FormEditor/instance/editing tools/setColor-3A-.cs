setColor: aColor
	"Set the mask (color) to aColor.
	Hacked to invoke color chooser if not B/W screen.
	Leaves the tool set in its previous state."

	self normalizeColor:  (unNormalizedColor := Display depth > 1
							ifTrue: [Color fromUser]
							ifFalse: [aColor]).
	tool _ previousTool