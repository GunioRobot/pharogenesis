contentsClipped: aString
	"Change my text, but do not change my size as a result"
	contents = aString ifTrue: [^ self].  "No substantive change"
	contents _ aString.
	self changed