roundCornersOf: aMorph on: aCanvas displayBlock: displayBlock borderWidth: w

	| rounder |
	rounder _ CR0.
	w = 1 ifTrue: [rounder _ CR1].
	w = 2 ifTrue: [rounder _ CR2].
	rounder _ rounder copy.
	rounder saveBitsUnderCornersOf: aMorph on: aCanvas.
	displayBlock value.
	rounder tweakCornersOf: aMorph on: aCanvas borderWidth: w