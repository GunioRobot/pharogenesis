nextText
	"returns the next textual segment"
	|start end|

	start _ pos.
	end _ (text indexOf: $< startingAt: start ifAbsent: [ text size + 1 ]) - 1.

	pos _ end+1.
	^HtmlText forSource: (text copyFrom: start to: end)