storeCodeOn: aStream indent: tabCount
	"Add in some smarts for division by zero."

	aStream nextPut: $(.
	(submorphs at: 1) storeCodeOn: aStream indent: tabCount.
	aStream space.
	(submorphs at: 2) storeCodeOn: aStream indent: tabCount.
	submorphs size > 2 ifTrue: [
		(self catchDivideByZero: aStream indent: tabCount) ifFalse: [
			aStream space.
			(submorphs at: 3) storeCodeOn: aStream indent: tabCount]].
	aStream nextPut: $).
