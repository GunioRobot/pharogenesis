decodeMimeHeader
	"See RFC 2047, MIME Part Three: Message Header Extension for Non-ASCII  
	Text. Text containing non-ASCII characters is encoded by the sequence  
	=?character-set?encoding?encoded-text?=  
	Encoding is Q (quoted printable) or B (Base64), handled by  
	Base64MimeConverter / RFC2047MimeConverter.

	Thanks to Yokokawa-san, it works in m17n package.  Try the following:

	'=?ISO-2022-JP?B?U1dJS0lQT1AvGyRCPUJDKyVpJXMlQRsoQi8=?= =?ISO-2022-JP?B?GyRCJVElRiUjJSobKEIoUGF0aW8p?=' decodeMimeHeader.
"
	| input output temp charset decoder encodedStream encoding pos |
	input _ ReadStream on: self.
	output _ WriteStream on: String new.
	[output
		nextPutAll: (input upTo: $=).
	"ASCII Text"
	input atEnd]
		whileFalse: [(temp _ input next) = $?
				ifTrue: [charset _ input upTo: $?.
					encoding _ (input upTo: $?) asUppercase.
					temp _ input upTo: $?.
					input next.
					"Skip final ="
					(charset isNil or: [charset size = 0]) ifTrue: [charset _ 'LATIN-1'].
					encodedStream _ MultiByteBinaryOrTextStream on: String new encoding: charset.
					decoder _ encoding = 'B'
								ifTrue: [Base64MimeConverter new]
								ifFalse: [RFC2047MimeConverter new].
					decoder
						mimeStream: (ReadStream on: temp);
						 dataStream: encodedStream;
						 mimeDecode.
					output nextPutAll: encodedStream reset contents.
					pos _ input position.
					input skipSeparators.
					"Delete spaces if followed by ="
					input peek = $=
						ifFalse: [input position: pos]]
				ifFalse: [output nextPut: $=;
						 nextPut: temp]].
	^ output contents