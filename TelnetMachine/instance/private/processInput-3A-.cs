processInput: aString
	"process input from the network"
	| newDisplayText |

	(processingCommand not and: [(aString indexOf: IAC) = 0]) ifTrue: [
		"no commands here--display the whole string"
		self displayString: aString.
		self changed: #displayBuffer.
		^self ].

	Transcript show: 'slow.'; cr.

	newDisplayText _ WriteStream on: String new.

	aString do: [ :c |
		processingCommand ifTrue: [
			"an IAC has been seen"
			commandChar
				ifNil: [ 
					"c is the command character.  act immediately if c=IAC, otherwise save it and wait fro the next character"
					commandChar _ c.  
					(commandChar = IAC) ifTrue: [ self displayChar: IAC. processingCommand _ false ] ]
				ifNotNil: [
					commandChar == DOChar ifTrue: [ self processDo: c. ].
					commandChar == DONTChar ifTrue: [ self processDont: c ].
					commandChar == WILLChar ifTrue: [ self processWill: c ].
					commandChar == WONTChar ifTrue: [ self processWont: c ].
					processingCommand _ false.  ] ]
		ifFalse: [
			"normal mode"
			c = IAC ifTrue: [ processingCommand _ true.  commandChar _ nil ] ifFalse: [
			  newDisplayText nextPut: c ] ] ].


	self displayString: newDisplayText contents.

	self changed: #displayBuffer
