unique: aTag in: aSet
	"If aTag is not in aSet, put it in and return aTag.  If it's there,
make up a new tag, insert it, and return it.  For keeping insertion points
in text unique, so can tell where to put incoming text."

	| base new |
	((aSet includes: aTag) not and: [aTag size > 0]) ifTrue: [aSet add:
aTag.  ^ aTag].
	base _ 0.
	[new _ (100 atRandom + base) printString.
		aSet includes: new] whileTrue:
			[base _ base + 50].
	aSet add: new.
	^ new