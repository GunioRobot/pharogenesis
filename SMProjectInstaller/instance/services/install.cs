install
	"This service should bring the package to the client, 
	unpack it if necessary and install it into the image. 
	The package is notified of the installation."

	Project canWeLoadAProjectNow ifFalse: [self error: 'Can not load Project now, probably because not in Morphic.'].
	self cache.
	[[ ProjectLoading openFromDirectory: dir andFileName: fileName ]
		on: ProgressTargetRequestNotification do: [ :ex | ex resume ]]
			ensure: [packageRelease noteInstalled]