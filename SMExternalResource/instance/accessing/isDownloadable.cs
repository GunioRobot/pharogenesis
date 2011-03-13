isDownloadable
	"Answer if I can be downloaded.
	We simply verify that the download url
	ends with a filename."

	^self downloadFileName isEmptyOrNil not