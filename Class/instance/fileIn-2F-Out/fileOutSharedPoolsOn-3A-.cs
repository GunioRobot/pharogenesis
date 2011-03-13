fileOutSharedPoolsOn: aFileStream
	"file out the shared pools of this class after prompting the user about each pool"
	| poolsToFileOut |
	poolsToFileOut _ self sharedPools select: 
		[:aPool | (self shouldFileOutPool: (Smalltalk keyAtValue: aPool))].
	poolsToFileOut do: [:aPool | self fileOutPool: aPool onFileStream: aFileStream].
	