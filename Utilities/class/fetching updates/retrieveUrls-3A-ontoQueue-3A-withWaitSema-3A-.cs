retrieveUrls: urls  ontoQueue: queue  withWaitSema: waitSema
	| doc |
	"download the given list of URLs.  The queue will be loaded alternately with url's and with the retrieved contents.  If a download fails, the contents will be #failed.  If all goes well, a special pair with an empty URL and the contents #finished will be put on the queue.  waitSema is waited on every time before a new document is downloaded; this keeps the downloader from getting too far ahead of the main process"

	"kill the existing downloader if there is one"
	UpdateDownloader ifNotNil: [ UpdateDownloader terminate ].

	"fork a new downloading process"
	UpdateDownloader := [ urls do: [ :url |
		waitSema wait.
		queue nextPut: url.
		doc _ HTTPSocket httpGet: url accept: 'application/octet-stream'.
		doc class == String
			ifTrue: [ queue nextPut: #failed.  Processor activeProcess terminate ]
			ifFalse: [ queue nextPut: doc] ] .

		queue nextPut: ''.
		queue nextPut: #finished.
	] newProcess.
	UpdateDownloader priority: Processor userInterruptPriority.


	"start the process running"
	UpdateDownloader resume.
