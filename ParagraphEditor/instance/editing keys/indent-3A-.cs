indent: characterStream
	"Add a tab at the front of every line occupied by the selection. Flushes typeahead.  Invoked from keyboard via cmd-shift-R.  2/29/96 sw"

	^ self inOutdent: characterStream delta: 1