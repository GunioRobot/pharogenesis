nextTag
	"we've seen a < and peek-ed something other than a !.  Parse and return a tag"
	| source negated name attribs attribName attribValue sourceStart sourceEnd c |
	
	sourceStart _ pos-1.
	attribs _ Dictionary new.

	"determine if its negated"
	self peekChar = $/
		ifTrue: [ negated _ true.  self nextChar. ]
		ifFalse: [ negated _ false ].

	"read in the name"
	self skipSpaces.
	name _ self nextName.
	name _ name asLowercase.

	"read in any attributes"
	[ 	self skipSpaces.
		c _ self peekChar.
		c = nil or: [c isLetter not ]
	] whileFalse: [
		attribName _ self nextName.
		attribName _ attribName asLowercase.
		self skipSpaces.
		self peekChar = $=
			ifTrue: [
				self nextChar.
				self skipSpaces.
				attribValue _ self nextAttributeValue withoutQuoting  ]
			ifFalse: [ attribValue _ '' ].
		attribs at: attribName  put: attribValue ].

	self skipSpaces.
	"determine if the tag is of the form <foo/>"
	self peekChar = $/ ifTrue: [ self nextChar. ].
	self skipSpaces.
	self peekChar = $> ifTrue: [ self nextChar ].

	sourceEnd _ pos-1.
	source _ text copyFrom: sourceStart to: sourceEnd.

	^HtmlTag source: source name: name asLowercase negated: negated attribs: attribs