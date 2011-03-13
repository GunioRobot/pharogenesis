withInternetLineEndings
	"change line endings from CR's to CRLF's.  This is probably in
prepration for sending a string over the Internet"
	| cr lf |
	cr := Character cr.
	lf := Character linefeed.
	^self class streamContents: [ :stream |
		self do: [ :c |
			stream nextPut: c.
			c = cr ifTrue:[ stream nextPut: lf ]. ] ].