storeAllInSegments
	"Write out all Projects in this Image.
	Project storeAllInSegments.		"

	| all ff ll |
all _ Project allProjects.
Transcript show: 'Initial Space Left: ', (ff _ Smalltalk garbageCollect) printString; cr.
all do: [:proj |
	Transcript show: proj name; cr.
	proj storeSegment  "storeSegmentNoFile"].
Transcript show: 'After writing all: ', (ll _ Smalltalk garbageCollect) printString; cr.
Transcript show: 'Space gained: ', (ll - ff) printString; cr.
"some will come back in"