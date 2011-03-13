getSourceFor: selector in: class
	"Retrieve or reconstruct the source code for this method."
	| source flagByte sourceSelector |
	flagByte _ self last.
	(flagByte = 0
		or: [flagByte = 251 "some source-less methods have flag = 251, rest = 0"
			and: [((1 to: 3) collect: [:i | self at: self size - i]) = #(0 0 0)]])
		ifTrue: ["No source pointer -- decompile without temp names"
		^ self decompileString].
	flagByte < 252 ifTrue:
		["Magic sources -- decompile with temp names"
		^ ((self decompilerClass new withTempNames: self tempNames)
				decompile: selector in: class method: self)
			decompileString].

	"Situation normal;  read the sourceCode from the file"
	
	[ source _ self getSourceFromFile ] on: Error do: [ :ex |
		"An error can happen here if, for example, the changes file has been truncated by an aborted download.  The present solution is to ignore the error and fall back on the decompiler.  A more thorough solution should probably trigger a systematic invalidation of all source pointers past the end of the changes file.  Consider that, as time goes on, the changes file will eventually grow large enough to cover the lost code, and then instead of falling into this error case, random source code will get returned."
		source _ nil ].
	
	source ifNotNil: [
		sourceSelector _ Parser parserClass new parseSelector: source.
		^sourceSelector = selector
			ifTrue: [source]
			ifFalse: [
				self replace: sourceSelector with: selector in: source]].

	"Something really wrong -- decompile blind (no temps)"
	^ self decompileString