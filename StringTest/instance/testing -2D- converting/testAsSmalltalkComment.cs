testAsSmalltalkComment
	| exampleStrings  |
	exampleStrings := #(
		''
		' '
		'"'
		'""'
		'"""'
		'abc"abc'
		'abc""abc'
		'abc"hello"abc'
		'abc"'
		'"abc' ).

	"check that the result of scanning the comment is empty"
	exampleStrings do: [ :s |
		| tokens  |
		tokens :=  Scanner new scanTokens: s asSmalltalkComment.
		self should: [ tokens isEmpty ] ].

	"check that the result has the same non-quote characters as the original"
	exampleStrings do: [ :s |
		self should: [
			(s copyWithout: $") = (s asSmalltalkComment copyWithout: $") ] ].

	"finnaly, test for some common kinds of inputs"
	self should: [ 'abc' asSmalltalkComment = '"abc"'. ].
	self should: [ 'abc"abc' asSmalltalkComment = '"abc""abc"'. ].
	self should: ['abc""abc' asSmalltalkComment = '"abc""abc"' ].
		