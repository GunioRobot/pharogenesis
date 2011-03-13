readFromFile: fileName mergeIfStereo: mergeFlag skipDataChunk: skipDataFlag
	"Read the AIFF file of the given name. If mergeFlag is true and the file contains stereo data, then the left and right channels will be mixed together as the samples are read in. If skipDataFlag is true, then the data chunk to be skipped; this allows the other chunks of a file to be processed in order to extract format information quickly without reading the data."
	"AIFFFileReader new readFromFile: 'test.aiff' mergeIfStereo: false skipDataChunk: true"

	| binaryStream |
	binaryStream _ (FileStream readOnlyFileNamed: fileName) binary.
	self readFrom: binaryStream mergeIfStereo: mergeFlag skipDataChunk: skipDataFlag
