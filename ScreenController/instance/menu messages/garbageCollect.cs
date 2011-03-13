garbageCollect
	"Do a garbage collection, and report results to the user."

	| cc |
	Smalltalk at: #Command ifPresent:
		[:cmdClass |
		(cc _ cmdClass instanceCount) > 0 ifTrue:
			[(self confirm: 'There are ' , cc printString , ' undo records in your system.
would you like to purge them prior to measuring space left?')
				ifTrue: [CommandHistory resetAllHistory]]].
	self inform: (Smalltalk bytesLeft asStringWithCommas, ' bytes available').
