selectorsInClass: aClass
	"Used by a ChangeSorter to access the list methods."

	^ (changeRecords at: aClass ifAbsent: [^#()]) changedSelectors