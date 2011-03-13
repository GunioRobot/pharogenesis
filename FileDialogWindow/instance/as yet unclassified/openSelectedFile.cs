openSelectedFile
	"Open a stream on the selected file if available and return it."

	|d f|
	d := self selectedFileDirectory ifNil: [^nil].
	f := self selectedFileName ifNil: [^nil].
	self selectedFileEntry isDirectory ifTrue: [^nil].
	^ (d oldFileNamed: f) ifNil: [d readOnlyFileNamed: f]