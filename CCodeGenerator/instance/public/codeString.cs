codeString
	"Return a string containing all the C code for the code base. Used for testing."

	| stream |
	stream _ ReadWriteStream on: (String new: 1000).
	self emitCCodeOn: stream doInlining: true doAssertions: true.
	^stream contents