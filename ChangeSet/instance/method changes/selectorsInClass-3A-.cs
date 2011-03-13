selectorsInClass: aClass
	"Used by a ChangeSorter to access the list methods."
	"later include class changes"
	^ (methodChanges at: aClass ifAbsent: [^#()]) keys