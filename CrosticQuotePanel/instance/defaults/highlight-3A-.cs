highlight: morph

	self unhighlight.
	cluesPanel unhighlight.
	morph startOfWord morphsInWordDo:
		[:m | m color: Color lightGreen.
		(cluesPanel letterMorphs at: m indexInQuote) color: Color lightMagenta].
	morph color: Color green.
	(cluesPanel letterMorphs at: morph indexInQuote) color: Color magenta.
