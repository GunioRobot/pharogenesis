withSqueakLineEndings
	"assume the string is textual, and that CR, LF, and CRLF are all 
	valid line endings.  Replace each occurence with a single CR"
	| cr lf input c crlf inPos outPos outString lineEndPos newOutPos |
	cr _ Character cr.
	lf _ Character linefeed.
	crlf _ CharacterSet new.
	crlf add: cr; add: lf.

	inPos _ 1.
	outPos _ 1.
	outString _
 String new: self size.

	[ lineEndPos _ self indexOfAnyOf: crlf startingAt: inPos ifAbsent: [0].
		lineEndPos ~= 0 ] whileTrue: [
			newOutPos _ outPos + (lineEndPos - inPos + 1).
			outString replaceFrom: outPos to: newOutPos - 2 with: self startingAt: inPos.
			outString at: newOutPos-1 put: cr.
			outPos _ newOutPos.

			((self at: lineEndPos) = cr and: [ lineEndPos < self size and: [ (self at: lineEndPos+1) = lf ] ]) ifTrue: [
				"CRLF ending"
				inPos _ lineEndPos + 2 ]
			ifFalse: [ 
				"CR or LF ending"
				inPos _ lineEndPos + 1 ]. ].

	"no more line endings.  copy the rest"
	newOutPos _ outPos + (self size - inPos + 1).
	outString replaceFrom: outPos to: newOutPos-1 with: self startingAt: inPos.

	^outString copyFrom: 1 to: newOutPos-1
	