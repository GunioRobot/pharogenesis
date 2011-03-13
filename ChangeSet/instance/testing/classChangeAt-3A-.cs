classChangeAt: className
	"Return what we know about class changes to this class."
	| this |

	this _ classChanges at: className ifAbsent: [Set new].
	(classRemoves includes: className) ifTrue: [this add: #remove].
	^ this