fileIn
	"File the receiver in.  If I represent a method or a class-comment, file the method in and make a note of it in the recent-submissions list; if I represent a do-it, then, well, do it."

	| methodClass s aSelector |
	Cursor read showWhile:
		[(methodClass := self methodClass) notNil ifTrue:
			[methodClass compile: self text classified: category withStamp: stamp notifying: nil.
			(aSelector := self methodSelector) ifNotNil:
				[Utilities noteMethodSubmission: aSelector forClass: methodClass]].
		(type == #doIt) ifTrue:
			[((s := self string) beginsWith: '----') ifFalse: [Compiler evaluate: s]].
		(type == #classComment) ifTrue:
			[ | cls | (cls := Smalltalk at: class asSymbol) comment: self text stamp: stamp.
			Utilities noteMethodSubmission: #Comment forClass: cls ]]