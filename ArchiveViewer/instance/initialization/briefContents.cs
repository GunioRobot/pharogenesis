briefContents
	"Trim to 5000 characters. If the member is longer, then point out that it is trimmed.
	Also warn if the member has a corrupt CRC-32."

	| stream subContents errorMessage |
	self selectedMember ifNil: [^ ''].
	errorMessage := ''.
	stream := WriteStream on: (String new: (self selectedMember uncompressedSize min: 5500)).

	[ self selectedMember uncompressedSize > 5000
		ifTrue: [ |  lastLineEndingIndex tempIndex |
			subContents := self selectedMember contentsFrom: 1 to: 5000.
			lastLineEndingIndex := subContents lastIndexOf: Character cr.
			tempIndex := subContents lastIndexOf: Character lf.
			tempIndex > lastLineEndingIndex ifTrue: [lastLineEndingIndex := tempIndex].
			lastLineEndingIndex = 0
				ifFalse: [subContents := subContents copyFrom: 1 to: lastLineEndingIndex]]
		ifFalse: [ subContents := self selectedMember contents ]]
			on: CRCError do: [ :ex |
				errorMessage := String streamContents: [ :s |
					s nextPutAll: '[ ';
						nextPutAll: (ex messageText copyUpToLast: $( );
						nextPutAll: ' ]' ].
				ex proceed ].

		(errorMessage isEmpty not or: [ self selectedMember isCorrupt ]) ifTrue: [
			stream nextPutAll: '********** WARNING! Member is corrupt! ';
					nextPutAll: errorMessage;
					nextPutAll: ' **********'; cr ].

	self selectedMember uncompressedSize > 5000
		ifTrue: [
			stream nextPutAll: 'File ';
				print: self selectedMember fileName;
				nextPutAll: ' is ';
				print: self selectedMember uncompressedSize;
				nextPutAll: ' bytes long.'; cr;
				nextPutAll: 'Click the ''View All Contents'' button above to see the entire file.'; cr; cr;
				nextPutAll: 'Here are the first ';
				print: subContents size;
				nextPutAll: ' characters...'; cr;
				next: 40 put: $-; cr;
				nextPutAll: subContents;
				next: 40 put: $-; cr;
				nextPutAll: '... end of the first ';
				print: subContents size;
				nextPutAll: ' characters.' ]
		ifFalse: [ stream nextPutAll: self selectedMember contents ].
		
		^stream contents
