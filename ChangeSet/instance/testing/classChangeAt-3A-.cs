classChangeAt: className
	"Return what we know about class changes to this class."
	^ classChanges at: className ifAbsent: [Set new].