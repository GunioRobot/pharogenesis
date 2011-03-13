testEnsureNoSpace
	"self debug: #testEnsureNoSpace"
	
	| stream |

	stream := WriteStream with: 'stream'.
	stream ensureNoSpace.
	self assert: stream contents = 'stream'.
	
	stream := WriteStream with: 'stream '.
	stream ensureNoSpace.
	self assert: stream contents = 'stream'.
	
	stream := WriteStream with: ' '.
	stream ensureNoSpace.
	self assert: stream contents = ''.