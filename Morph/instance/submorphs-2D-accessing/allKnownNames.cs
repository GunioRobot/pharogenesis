allKnownNames
	"Return a list of all known names based on the scope of the receiver"
	| allNames theName |
	self isPartsBin ifTrue:[^#()]. "Don't report names from parts bins"
	allNames _ WriteStream on: #().
	self submorphsDo:[:m|
		(theName _ m knownName) ifNotNil:[allNames nextPut: theName].
		allNames nextPutAll: m allKnownNames.
	].
	^allNames contents