outdent: characterStream
	"Remove a tab from the front of every line occupied by the selection. Flushes typeahead.  Invoked from keyboard via cmd-shift-L.  2/29/96 sw"

	^ self inOutdent: characterStream delta: -1