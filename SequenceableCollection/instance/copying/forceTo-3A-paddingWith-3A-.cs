forceTo: length paddingWith: elem
	"Force the length of the collection to length, padding if necissary
	with elem.  Note that this makes a copy."
	| newCollection copyLen |
	newCollection _ self species new: length.
	copyLen _ self size.
	1 to: length do: [ :index |
		(index <= copyLen) ifTrue: [
			newCollection at: index put: (self at: index) ]
		ifFalse: [
			newCollection at: index put: elem ] ].
	^ newCollection