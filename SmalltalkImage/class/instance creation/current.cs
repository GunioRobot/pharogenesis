current
	"Note that this could be implemented differently to avoid the test"

	current isNil
		ifTrue: [current := self basicNew].
	^ current