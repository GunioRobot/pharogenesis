initializeWith: aWonderland
	"Do the Wonderland specific setup for this viewer."

	thumbnailCamera _ WonderlandStillCamera createFor: aWonderland.
	thumbnailCamera turnBackgroundOff.

	thumbnailMorph _ thumbnailCamera getMorph.
	thumbnailMorph topLeft: 10@10.
	self addMorph: thumbnailMorph.
