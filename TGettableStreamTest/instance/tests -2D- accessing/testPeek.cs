testPeek
	| stream |
	stream := self streamOnArray.
	
	self assert: stream peek = 1.
	self deny: stream peek = #(a b c).
	self deny: stream peek = false.
	
	stream next.
	
	self deny: stream peek = 1.
	self assert: stream peek = #(a b c).
	self deny: stream peek = false.
	
	stream next.
	
	self deny: stream peek = 1.
	self deny: stream peek = #(a b c).
	self assert: stream peek = false.
	
	stream next.
	
	"In ANSI Smalltalk Standard Draft, it is said that nil will return nil at the end when using #peek."
	self assert: stream peek isNil.