docObjectAt: classAndMethod
	"Return a morphic object that is the documentation pane for this method.  nil if none can be found.  Look on both the network and the disk."

	| fileNames server aUrl strm local obj |
	methodVersions size = 0 ifTrue: [self updateMethodVersions].	"first time"
	fileNames _ self docNamesAt: classAndMethod.
	self assureCacheFolder.
	"server _ (ServerDirectory serverInGroupNamed: group) clone."  "Note: directory ends with '/updates' which needs to be '/docpane', but altUrl end one level up"
	server _ ServerDirectory serverInGroupNamed: group.
		"later try multiple servers"
	aUrl _ server altUrl, 'docpane/'.
	fileNames do: [:aVersion | 
		strm _ HTTPSocket httpGetNoError: aUrl,aVersion 
			args: nil accept: 'application/octet-stream'.
		strm class == RWBinaryOrTextStream ifTrue: [
			self cache: strm as: aVersion.
			strm reset.
			obj _ strm fileInObjectAndCode asMorph.
			(obj valueOfProperty: #classAndMethod) = classAndMethod ifFalse: [
				self inform: 'suspicious object'.
				obj setProperty: #classAndMethod toValue: classAndMethod].
			^ obj].	"The pasteUpMorph itself"
		"If file not there, error 404, just keep going"].
	local _ ServerDirectory new fullPath: DocsCachePath.
	"check that it is really there -- let user respecify"
	fileNames do: [:aVersion | 
		(local includesKey: aVersion) ifTrue: [
			strm _ local readOnlyFileNamed: aVersion.
			obj _ strm fileInObjectAndCode asMorph.
			(obj valueOfProperty: #classAndMethod) = classAndMethod ifFalse: [
				self inform: 'suspicious object'.
				obj setProperty: #classAndMethod toValue: classAndMethod].
			Transcript cr; show: 'local cache: ', aVersion.
			^ obj].	"The pasteUpMorph itself"
		"If file not there, just keep looking"].
	"Never been documented"
	^ nil