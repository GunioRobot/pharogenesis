decodeMimeHeader
	"See RFC 2047, MIME Part Three: Message Header Extension for Non-ASCII Text.
	Text containing non-ASCII characters is encoded by the sequence
		=?character-set?encoding?encoded-text?=
	Encoding is Q (quoted printable) or B (Base64), handled by Base64MimeConverter / RFC2047MimeConverter. The character-set (usually iso-8859-1) is ignored"

	| input output temp decoder encoding pos | 
	input _ ReadStream on: self.
	output _ WriteStream on: String new.

	[output nextPutAll: (input upTo: $=).	"ASCII Text"
	input atEnd] whileFalse: [
		(temp _ input next) = $?
			ifFalse: [output nextPut: $=; nextPut: temp]
			ifTrue: [
				input skipTo: $?. "Skip charset"
				encoding _ (input upTo: $?) asUppercase.
				temp _ input upTo: $?.
				input next.	"Skip final ="
				decoder _ encoding = 'B'
					ifTrue: [Base64MimeConverter new]
					ifFalse: [RFC2047MimeConverter new].
				decoder
					mimeStream: (ReadStream on: temp);
					dataStream: output;
					mimeDecode.
				pos _ input position.
				input skipSeparators.	"Delete spaces if followed by ="
				input peek = $= ifFalse: [input position: pos]]].
	^output contents