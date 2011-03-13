bestAccessToFileName: aFileName andDirectory: aDirectoryOrUrlString
	"Answer an array with a stream and a directory. The directory can be nil."
	
	| dir url |
	dir := Project squeakletDirectory.
	(dir fileExists: aFileName) ifTrue: [
		^{dir readOnlyFileNamed: aFileName. dir}].

	aDirectoryOrUrlString isString ifFalse: [
		^{aDirectoryOrUrlString readOnlyFileNamed: aFileName. aDirectoryOrUrlString}].

	url := Url absoluteFromFileNameOrUrlString: aDirectoryOrUrlString.

	(url scheme = 'file') ifTrue: [
		dir := FileDirectory on: url pathForDirectory.
		^{dir readOnlyFileNamed: aFileName. dir}].

	^{ServerFile new fullPath: aDirectoryOrUrlString. nil}