versionForFileName: version
	"Project versionForFileName: 7"
	| v |
	^String streamContents:[:s|
		v _ version printString.
		v size < 3 ifTrue:[v _ '0', v].
		v size < 3 ifTrue:[v _ '0', v].
		s nextPutAll: v.
	]
