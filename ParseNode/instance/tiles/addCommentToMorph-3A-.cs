addCommentToMorph: aMorph
	| row |
	(comment isNil or: [comment isEmpty]) ifTrue: [^ self].
	row _ aMorph addTextRow:
		(String streamContents: [:strm | self printCommentOn: strm indent: 1]).
	row firstSubmorph color: (SyntaxMorph translateColor: #comment).
	row parseNode: (self as: CommentNode).
