tocSize
	"return the size of the TOC"
	mailDB ifNil: [ ^0 ].
	^currentMessages size