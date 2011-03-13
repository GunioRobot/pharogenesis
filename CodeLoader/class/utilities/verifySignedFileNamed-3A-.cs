verifySignedFileNamed: aFileName
	"CodeLoader verifySignedFileNamed: 'signed\dummy1.dsq' "

	| secured signedFileStream |
	signedFileStream _ FileStream fileNamed: aFileName.
	secured _ CodeLoader new positionedToSecuredContentsOf: signedFileStream.
	signedFileStream close.
	Transcript show: aFileName , ' verified: '; show: secured printString; cr.

