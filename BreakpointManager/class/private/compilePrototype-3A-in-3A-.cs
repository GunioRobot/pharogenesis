compilePrototype: aSymbol in: aClass 
	"Compile and return a new method containing a break statement"

	| source node method |
	source := self breakpointMethodSourceFor: aSymbol in: aClass.
	node := aClass compilerClass new
		compile: source
		in: aClass 
		notifying: nil 
		ifFail: [self error: '[breakpoint] unable to install breakpoint'].
	node isNil ifTrue: [^nil].
	"dunno what the arguments mean..."
	method := node generate: #(0 0 0 0).
	^method