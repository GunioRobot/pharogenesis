save
	| fileName decoder file decoderClass bufferStream |
	(fileName _ self name) ifNil: [fileName _ FillInTheBlank request: 'File name for save?' initialAnswer: 'attachment' , Utilities dateTimeSuffix].
	fileName ifNil: [^ nil].
	file _ FileStream newFileNamed: fileName.
	file binary.
	(decoderClass _ self decoderClass) ifNil: ["decoder not needed or unknown"
		file nextPutAll: self content]
		ifNotNil: 
			[decoder _ decoderClass new.
			bufferStream _ WriteStream on: String new.
			decoder dataStream: bufferStream;
			 mimeStream: (ReadStream on: self content);
			 mimeDecode.
			file nextPutAll: bufferStream contents asByteArray].
	file close 