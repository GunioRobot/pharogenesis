lineCount
	"Answer the number of lines represented by the receiver, where every cr adds one line.  5/10/96 sw"

	| cr count |
	cr := Character cr.
	count := 1  min: self size..
	1 to: self size do:
		[:i | (self at: i) = cr ifTrue: [count := count + 1]].
	^ count

"
'Fred
the
Bear' lineCount
"