parseFileNamed: aString
	"Answer a dictionary of name->RenderObject associations"
	^self parseFileNamed: aString using: self defaultSpec.