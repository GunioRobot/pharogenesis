parse: aStream
	"Answer a dictionary of name->RenderObject associations"
	^self parse: aStream using: self defaultSpec.