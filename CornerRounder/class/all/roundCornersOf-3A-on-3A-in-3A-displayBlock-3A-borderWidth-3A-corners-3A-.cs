roundCornersOf: aMorph on: aCanvas in: bounds displayBlock: displayBlock borderWidth: w corners: aList

	| rounder |
	rounder _ CR0.
	w = 1 ifTrue: [rounder _ CR1].
	w = 2 ifTrue: [rounder _ CR2].
	rounder _ rounder copy.
	rounder saveBitsUnderCornersOf: aMorph on: aCanvas in: bounds corners: aList.
	displayBlock value.
	rounder tweakCornersOf: aMorph on: aCanvas in: bounds borderWidth: w corners: aList