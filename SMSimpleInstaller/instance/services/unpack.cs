unpack
	"This basic installer simply checks the file extension of
	the downloaded file to choose suitable method for unpacking.
	Currently it only supports .gz decompression.
	If a file exists with the same name it is first deleted.
	The unpacked filename is set on succesfull decompression or
	if the file was not recognized as a compressed file."

	| unzipped zipped buffer |
	(fileName endsWith: '.gz')
		ifTrue:[
			unpackedFileName := fileName copyUpToLast: FileDirectory extensionDelimiter.
			(dir fileExists: unpackedFileName) ifTrue:[ dir deleteFileNamed: unpackedFileName ].
			unzipped := dir newFileNamed: unpackedFileName.
			unzipped binary.
			zipped := GZipReadStream on: ((dir readOnlyFileNamed: fileName) binary; yourself).
			buffer := ByteArray new: 50000.
			'Extracting ' , fileName
				displayProgressAt: Sensor cursorPoint
				from: 0
				to: zipped sourceStream size
				during: [:bar | 
					[zipped atEnd]
						whileFalse: 
							[bar value: zipped sourceStream position.
							unzipped nextPutAll: (zipped nextInto: buffer)].
					zipped close.
					unzipped close]]
		ifFalse:[unpackedFileName := fileName]