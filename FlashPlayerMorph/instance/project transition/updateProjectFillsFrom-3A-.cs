updateProjectFillsFrom: aProject
	"Update all the project target fills from the given project"
	| fillStyles projImage |
	fillStyles _ self valueOfProperty: #projectTargetFills ifAbsent:[^self].
	fillStyles isEmpty ifTrue:[^self].
	projImage _ aProject imageFormOfSize: Display extent depth: 8.
	fillStyles keysDo:[:fs| fs form: projImage].
	"Note: We must issue a full GC here for cleaning up the old bitmaps"
	Smalltalk garbageCollect.