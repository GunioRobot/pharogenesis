readFromStream: aBinaryStream mergeIfStereo: mergeFlag skipDataChunk: skipDataFlag
	"Read an AIFF file from the given binary stream. If mergeFlag is true and the file contains stereo data, then the left and right channels will be mixed together as the samples are read in. If skipDataFlag is true, then the data chunk to be skipped; this allows the other chunks of a file to be processed in order to extract format information quickly without reading the data."

	mergeIfStereo _ mergeFlag.
	skipDataChunk _ skipDataFlag.
	isLooped _ false.
	gain _ 1.0.
	self readFrom: aBinaryStream.
