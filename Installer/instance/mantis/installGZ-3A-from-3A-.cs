installGZ: aFileName from: stream 

	"FileIn the contents of a gzipped stream"

	| zipped unzipped |
	 
	zipped := self classGZipReadStream on: stream.
	unzipped := MultiByteBinaryOrTextStream with: zipped contents asString.
	unzipped reset.

	self  newChangeSetFromStream: unzipped named:aFileName.

	