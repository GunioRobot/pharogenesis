includes: anSMObject
	"Check if the cache holds the file for the object."
	
	^(anSMObject cacheDirectory)
		fileExists: anSMObject downloadFileName