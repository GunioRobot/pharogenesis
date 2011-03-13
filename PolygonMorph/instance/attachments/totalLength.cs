totalLength
	"Answer the full length of my segments. Can take a long time if I'm curved."
	| length |
	length _ 0.
	self lineSegmentsDo: [ :a :b | length _ length + (a dist: b) ].
	^length.