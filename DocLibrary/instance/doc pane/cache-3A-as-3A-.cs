cache: strm as: fileName
	"Save the file locally in case the network is not available."

	| local |
	local _ ServerDirectory new fullPath: DocsCachePath.
	(local fileNamed: fileName) nextPutAll: strm contents; close.