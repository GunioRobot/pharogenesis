versionedFileName
	"Project current versionedFileName"
	| v |
	^String streamContents:[:s|
		s nextPutAll: self name.
		s nextPutAll: FileDirectory dot.
		v _ self currentVersionNumber printString.
		v size < 3 ifTrue:[v _ '0', v].
		v size < 3 ifTrue:[v _ '0', v].
		s nextPutAll: v.
		s nextPutAll: FileDirectory dot.
		s nextPutAll: self projectExtension.
	]
