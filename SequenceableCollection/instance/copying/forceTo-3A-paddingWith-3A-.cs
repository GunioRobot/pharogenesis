forceTo: length paddingWith: elem
	"Force the length of the collection to length, padding
	if necessary with elem.  Note that this makes a copy."

	| newCollection copyLen |
	newCollection := self species new: length.
	copyLen := self size min: length.
	newCollection replaceFrom: 1 to: copyLen with: self startingAt: 1.
	newCollection from: copyLen + 1 to: length put: elem.
	^ newCollection