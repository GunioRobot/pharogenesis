scanToNextAndSigns: aStream
	"Scan the stream for 5 consecutive and-sign (&) characters.  If they are found, position the stream at the start of the and-signs and answer true.  Answer false if the end of the stream is reached"

	| chunk index blocksize target |

	target _ '&&&&&'.
	blocksize _ 4000.		"Must be more than target size :-)"

	"Quickly skip over sections that do not have and-signs."
	index _ 0.
	[index = 0]
		whileTrue:
			[chunk _ aStream next: blocksize.
			aStream atEnd ifTrue: [ ^false ]. "end of file"
			index _ chunk findString: target.

			"Handle the yucky case where the target might be split between
			this block and the next.  We back up a bit before continuing.
			We back up 4, since the whole target is clearly not there"
			(index = 0 and: [chunk size = blocksize]) ifTrue: [aStream skip: -4]. 
			].

	"We found some &s, so position the stream to read it"
	aStream skip: (chunk size - index + 1) negated.
	[aStream peek = $&] assert.
	^true
