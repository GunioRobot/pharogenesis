protected: aBlock
	"Execute aBlock protected by the accessLock"
	^accessLock isNil
		ifTrue:[aBlock value]
		ifFalse:[accessLock critical: aBlock ifError:[:msg :rcvr| rcvr error: msg]]