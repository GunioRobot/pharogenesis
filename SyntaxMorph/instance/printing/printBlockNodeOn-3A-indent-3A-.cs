printBlockNodeOn: strm indent: level

	| lev inASyntaxButNotOutermost subNodeClass |

	lev := level.
	inASyntaxButNotOutermost := owner isSyntaxMorph and: [ owner isMethodNode not].
	inASyntaxButNotOutermost ifTrue: [strm nextPut: $[.  lev := lev+1].
	self
		submorphsDoIfSyntax: [ :sub |
			sub printOn: strm indent: lev.
			subNodeClass := sub parseNode class.
			(#(BlockArgsNode ReturnNode CommentNode) includes: subNodeClass name) ifFalse: [
				strm ensureNoSpace; nextPut: $.].
			subNodeClass == BlockArgsNode
				ifTrue: [strm space]
				ifFalse: [strm crtab: lev].
		] 
		ifString: [ :sub |
			self printSimpleStringMorph: sub on: strm
		].
	inASyntaxButNotOutermost ifTrue: [strm nextPut: $] ].

