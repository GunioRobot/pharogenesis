selectedClass
	"Answer the currently selected class."

	| pairString |
	classListIndex = 0 ifTrue: [^nil].
	pairString _ classList at: classListIndex.
	(pairString includes: $*) ifTrue: [pairString _ pairString allButFirst].
	MessageSet parse: pairString
		toClassAndSelector: [:cls :sel | ^ cls].