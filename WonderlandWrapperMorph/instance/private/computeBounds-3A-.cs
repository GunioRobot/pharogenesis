computeBounds: morph
	| box |
	box _ myActor getFullBoundsFor: morph getCamera.
	box == nil ifFalse:[bounds _ box].