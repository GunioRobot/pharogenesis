fileIn: fullFileName
	"FileIn the contents of a gzipped file"
	| zipped unzipped |
	zipped _ self on: (FileStream readOnlyFileNamed: fullFileName).
	unzipped _ MultiByteBinaryOrTextStream with: (zipped contents asString).
	unzipped reset.
	unzipped fileIn.
