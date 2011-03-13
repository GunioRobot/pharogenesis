browseCompressedChangesFile: fullName 
	"Browse the selected file in fileIn format."

	| zipped unzipped stream |
	fullName ifNil: [^Beeper beep].
	stream := FileStream readOnlyFileNamed: fullName.
	[stream converter: Latin1TextConverter new.
	zipped := GZipReadStream on: stream.
	unzipped := zipped contents asString]
		ensure: [stream close].
	stream := (MultiByteBinaryOrTextStream with: unzipped) reset.
	ChangeList browseStream: stream