fileInAnnouncing: announcement 
	"This is special for reading expressions from text that has been formatted 
	with exclamation delimitors. The expressions are read and passed to the 
	Compiler. Answer the result of compilation.  Put up a progress report with
     the given announcement as the title."

	| val chunk |
	announcement 
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: self size
		during: 
			[:bar | 
			[self atEnd] whileFalse: 
					[bar value: self position.
					self skipSeparators.
					
					[val := (self peekFor: $!) 
								ifTrue: [(Compiler evaluate: self nextChunk logged: false) scanFrom: self]
								ifFalse: 
									[chunk := self nextChunk.
									self checkForPreamble: chunk.
									Compiler evaluate: chunk logged: true]] 
							on: InMidstOfFileinNotification
							do: [:ex | ex resume: true].
					self skipStyleChunk].
			self close].
	"Note:  The main purpose of this banner is to flush the changes file."
	SmalltalkImage current logChange: '----End fileIn of ' , self name , '----'.
	self flag: #ThisMethodShouldNotBeThere.	"sd"
	Smalltalk forgetDoIts.
	^val