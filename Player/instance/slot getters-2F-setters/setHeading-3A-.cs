setHeading: newHeading
	"Set the heading as indicated"

	| aCostume |
	aCostume _ self costume.
	aCostume isWorldMorph ifTrue: [^ self].
	(newHeading closeTo: aCostume heading) ifTrue: [^ self].
	aCostume heading: newHeading.
	aCostume _ self costume. "in case we just got flexed for no apparent reason"
	(aCostume isFlexMorph and:[aCostume hasNoScaleOrRotation]) 
		ifTrue:	[aCostume removeFlexShell]