selectedClass
	"Answer the currently selected class."

	| pairString |

	self flag: #mref.	"allows for old-fashioned style"

	classListIndex = 0 ifTrue: [^nil].
	pairString _ classList at: classListIndex.
	(pairString isKindOf: MethodReference) ifTrue: [
		^pairString actualClass
	].
	(pairString includes: $*) ifTrue: [pairString _ pairString allButFirst].
	MessageSet 
		parse: pairString
		toClassAndSelector: [:cls :sel | ^ cls].