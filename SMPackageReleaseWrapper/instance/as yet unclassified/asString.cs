asString
	"Show installed releases with a trailing asterisk."
	
	^ item isInstalled
		ifTrue: [item smartVersion, ' *']
		ifFalse: [item smartVersion]