grabScreenAndSaveOnDisk  "Utilities grabScreenAndSaveOnDisk"
	| form fileName |
	form _ Form fromUser.
	form bits size = 0 ifTrue: [^ self beep].
	fileName _ FileDirectory default nextNameFor: 'Squeak' extension: 'gif'.
	Utilities informUser: 'Writing ' , fileName
		during: [GIFReadWriter putForm: form onFileNamed: fileName].