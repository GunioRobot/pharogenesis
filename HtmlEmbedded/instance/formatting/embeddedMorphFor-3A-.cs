embeddedMorphFor: url
	| morphClass |
	morphClass _ self embeddedMorphClassFor: url.
	^morphClass ifNotNil:[morphClass new]