scripts
	"Answer the receiver's scripts -- an IdentityDictionary"

	scripts
		ifNil:
			[scripts _ IdentityDictionary new]
		ifNotNil:
			[self cleanseScriptsOfNilKeys].
	^ scripts