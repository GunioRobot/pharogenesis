highlight: morph

	self unhighlight.
	quotePanel unhighlight.
	morph startOfWord morphsInWordDo:
		[:m | m color: Color lightGreen.
		(quotePanel letterMorphs at: m indexInQuote) color: Color lightMagenta].
	morph color: Color green.
	(quotePanel letterMorphs at: morph indexInQuote) color: Color magenta.
