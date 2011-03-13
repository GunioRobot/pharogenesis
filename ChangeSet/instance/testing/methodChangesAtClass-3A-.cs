methodChangesAtClass: className
	"Return what we know about method changes to this class."
	^ methodChanges at: className ifAbsent: [Dictionary new].