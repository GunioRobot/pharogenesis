versionForFileName: version
	"Project versionForFileName: 7"
	| v |
	^String streamContents:[:s|
		v := version printString.
		v size < 3 ifTrue:[v := '0', v].
		v size < 3 ifTrue:[v := '0', v].
		s nextPutAll: v.
	]
