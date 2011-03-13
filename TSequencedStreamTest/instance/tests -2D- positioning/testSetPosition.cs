testSetPosition
	| stream |

	stream := self emptyStream.
	self should: [stream position: -2] raise: Error.
	self shouldnt: [stream position: 0] raise: Error.

	stream := self streamOnArray.
	self should: [stream position: -1] raise: Error.
	self shouldnt: [stream position: 0] raise: Error.
	self shouldnt: [stream position: 1] raise: Error.
	self shouldnt: [stream position: 2] raise: Error.

	"According to ANSI Smalltalk Standard 1.9 Draft, the following should be tested too:
	self should: [stream position: 3] raise: Error.
	
	However, I don't see the point of raising an error when positioning at the end.
	
	I prefer testing the absence of error:
	"
	self shouldnt: [stream position: 3] raise: Error.
	self should: [stream position: 4] raise: Error.