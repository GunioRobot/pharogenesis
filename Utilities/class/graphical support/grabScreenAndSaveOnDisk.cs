grabScreenAndSaveOnDisk  "Utilities grabScreenAndSaveOnDisk"
	| form fileName |
	self deprecated: 'Use GIFReaderWriter grabScreenAndSaveOnDisk'.
	form _ Form fromUser.
	form bits size = 0 ifTrue: [^ Beeper beep].
	fileName _ FileDirectory default nextNameFor: 'Squeak' extension: 'gif'.
	Utilities informUser: 'Writing ' , fileName
		during: [GIFReadWriter putForm: form onFileNamed: fileName].