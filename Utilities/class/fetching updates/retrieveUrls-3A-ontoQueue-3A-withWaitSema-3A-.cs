retrieveUrls: urls ontoQueue: queue withWaitSema: waitSema 
	"download the given list of URLs. The queue will be loaded alternately  
	with url's and with the retrieved contents. If a download fails, the  
	contents will be #failed. If all goes well, a special pair with an empty  
	URL and the contents #finished will be put on the queue. waitSema is  
	waited on every time before a new document is downloaded; this keeps 
	the downloader from getting too far  ahead of the main process"
	"kill the existing downloader if there is one"
	| doc canPeek front |
	UpdateDownloader
		ifNotNil: [UpdateDownloader terminate].
	"fork a new downloading process"
	UpdateDownloader _ [urls
				do: [:url | 
					waitSema wait.
					queue nextPut: url.
					doc _ HTTPClient httpGet: url.
					doc isString
						ifTrue: [queue nextPut: #failed.
							UpdateDownloader _ nil.
							Processor activeProcess terminate]
						ifFalse: [canPeek _ 120 min: doc size.
							front _ doc next: canPeek.  doc skip: -1 * canPeek.
							(front beginsWith: '<!DOCTYPE') ifTrue: [
								(front includesSubString: 'Not Found') ifTrue: [
									queue nextPut: #failed.
									UpdateDownloader _ nil.
									Processor activeProcess terminate]]].
						UpdateDownloader ifNotNil: [queue nextPut: doc]].
			queue nextPut: ''.
			queue nextPut: #finished.
			UpdateDownloader _ nil] newProcess.
	UpdateDownloader priority: Processor userInterruptPriority.
	"start the process running"
	UpdateDownloader resume