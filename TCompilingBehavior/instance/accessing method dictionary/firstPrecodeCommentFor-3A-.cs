firstPrecodeCommentFor:  selector
	"If there is a comment in the source code at the given selector that preceeds the body of the method, return it here, else return nil"

	| parser source tree |
	"Behavior firstPrecodeCommentFor: #firstPrecodeCommentFor:"
	(#(Comment Definition Hierarchy) includes: selector)
		ifTrue:
			["Not really a selector"
			^ nil].
	source _ self sourceCodeAt: selector asSymbol ifAbsent: [^ nil].
	parser _ self parserClass new.
	tree _ 
		parser
			parse: (ReadStream on: source)
			class: self
			noPattern: false
			context: nil
			notifying: nil
			ifFail: [^ nil].
	^ (tree comment ifNil: [^ nil]) first