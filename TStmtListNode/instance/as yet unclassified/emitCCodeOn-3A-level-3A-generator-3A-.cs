emitCCodeOn: aStream level: level generator: aCodeGen

	statements do: [:s |
		s emitCCommentOn: aStream level: level.
		aStream tab: level.
		s emitCCodeOn: aStream level: level generator: aCodeGen.
		((self endsWithCloseBracket: aStream) or:
		 [s isComment])
			ifFalse: [aStream nextPut: $;].
		aStream cr].
