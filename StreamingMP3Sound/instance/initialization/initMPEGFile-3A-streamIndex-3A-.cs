initMPEGFile: anMPEGFile streamIndex: anInteger
	"Initialize for playing the given stream of the given MPEG or MP3 file."

	volume _ 0.3.
	repeat _ false.
	mpegFile _ anMPEGFile.
	mpegStreamIndex _ anInteger.
	totalSamples _ mpegFile audioSamples: mpegStreamIndex.
	self reset.
