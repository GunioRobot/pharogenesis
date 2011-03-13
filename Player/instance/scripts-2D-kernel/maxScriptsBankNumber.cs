maxScriptsBankNumber
	"later make sensitive to number of user scripts, and more general."
	^ self  class namedTileScriptSelectors size > 11
		ifTrue:
			[5]
		ifFalse:
			[4]
