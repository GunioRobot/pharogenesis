browseCompressedCodeStream: aStandardFileStream 
	"Browse the selected file in fileIn format."
	| zipped unzipped |
	zipped _ GZipReadStream on: aStandardFileStream.
	unzipped _ MultiByteBinaryOrTextStream with: zipped contents asString.
	unzipped reset.
	self browseStream: unzipped named: aStandardFileStream name.