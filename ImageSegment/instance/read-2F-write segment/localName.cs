localName
	| segs ind sep |
	"Return the current file name for this segment, a local name in the segments directory."

	fileName ifNil: [^ nil].
	"^ fileName"	

	"The following is for backward compatibility.  Remove this part after June 2000.
	Check if the fileName is a full path, and make it local.  Regardless of current or previous file system delimiter."

	segs _ self class folder copyLast: 4.  "_segs"
	ind _ 1.
	[ind _ fileName findString: segs startingAt: ind+1 caseSensitive: false.
		ind = 0 ifTrue: [^ fileName].
		sep _ fileName at: ind + (segs size).
		sep isAlphaNumeric ] whileTrue.		"sep is letter or digit, not a separator"

	^ fileName _ fileName copyFrom: ind+(segs size)+1 "delimiter" to: fileName size