selectedClassName
	"Answer the name of the current class. Answer nil if no selection exists."

	classListIndex = 0 ifTrue: [^nil].
	^self classList at: classListIndex