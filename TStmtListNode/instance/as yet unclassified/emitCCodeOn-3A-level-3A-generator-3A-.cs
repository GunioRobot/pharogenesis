emitCCodeOn: aStream level: level generator: aCodeGen

	statements do: [:s |
		level timesRepeat: [aStream tab].
		s emitCCodeOn: aStream level: level generator: aCodeGen.
		((self endsWithCloseBracket: aStream) or:
		 [s isComment])
			ifFalse: [aStream nextPut: $;].
		aStream cr].
