next
	"Returns the next 'final' point, e.g., one that will not be affected by simplification later"
	| thePoint |
	(finalPoint notNil and:[finalPoint isFinal]) ifFalse:[^nil].
	thePoint _ finalPoint.
	finalPoint _ finalPoint nextPoint.
	^thePoint