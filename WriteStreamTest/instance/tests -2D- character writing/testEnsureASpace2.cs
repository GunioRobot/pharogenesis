testEnsureASpace2
	"self debug: #testEnsureASpace2"
	| stream |
	stream := WriteStream on: String new.
	stream ensureASpace.
	self assert: stream contents = ' '.
	