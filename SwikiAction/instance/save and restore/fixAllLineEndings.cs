fixAllLineEndings
	"for each page in the swiki, fixes line endings to be CR only.
This is used to bring older Swikis up to date with the newer convention.
If a page has no LF's, then it is left alone"
	| origText newText pagesDone |
	pagesDone _ 0.
	'updating pages...' displayProgressAt: Sensor cursorPoint from: 0
to: urlmap pages size during: [ :bar |
		urlmap pages do: [ :page |
			origText _ page text.
			newText _ origText withSqueakLineEndings.
			origText = newText ifFalse: [ page text: newText ].

			pagesDone _ pagesDone + 1.
			bar value: pagesDone. ] ]