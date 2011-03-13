fileOutCategory: category withSuffix: aSuffix
	"Store on the file named category (a string) concatenated withaSuffix all the 
	classes associated with the category."
	| aFileStream |
	aFileStream _ FileStream newFileNamed: (category , aSuffix) asFileName.
	self fileOutCategory: category on: aFileStream.
	aFileStream close