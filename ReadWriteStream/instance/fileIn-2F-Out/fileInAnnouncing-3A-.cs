fileInAnnouncing: announcement
	"This is special for reading expressions from text that has been formatted 
	with exclamation delimitors. The expressions are read and passed to the 
	Compiler. Answer the result of compilation.  Put up a progress report with
     the given announcement as the title."
	| val chunk |
	announcement displayProgressAt: Sensor cursorPoint
		from: 0 to: self size
		during:
		[:bar |
		[self atEnd]
			whileFalse: 
				[bar value: self position.
				self skipSeparators.
				val _ (self peekFor: $!)
					ifTrue: [(Compiler evaluate: self nextChunk logged: false)
								scanFrom: self]
					ifFalse: [chunk _ self nextChunk.
							self checkForPreamble: chunk.
							Compiler evaluate: chunk logged: true].
				self skipStyleChunk].
		self close].
	^ val