trimLinesTo: lastLineInteger
	"Since ListParagraphs are not designed to be changed, we can cut back the
		lines field to lastLineInteger."
	lastLine := lastLineInteger.
	lines := lines copyFrom: 1 to: lastLine