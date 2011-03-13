report
	"answer a description of the current state of the cache"
	| usedPercent |
	usedPercent := maximumSize isNil
		ifTrue:[0]
		ifFalse:[(used * 100 / maximumSize) asFloat rounded].
	^usedPercent asString,'% Full (maximumSize: ', maximumSize asString, ' , used: ', used asString,')'