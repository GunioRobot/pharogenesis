noCommentNagString

	^ Preferences browserNagIfNoClassComment
		ifTrue: [Text string: 'THIS CLASS HAS NO COMMENT!' translated attribute: TextColor red]
		ifFalse: ['']
		