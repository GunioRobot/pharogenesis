retrieveUrls: urls ontoQueue: queue withWaitSema: waitSema 
	"download the given list of URLs. The queue will be loaded alternately  
	with url's and with the retrieved contents. If a download fails, the  
	contents will be #failed. If all goes well, a special pair with an empty  
	URL and the contents #finished will be put on the queue. waitSema is  
	waited on every time before a new document is downloaded; this keeps 
	the downloader from getting too far  ahead of the main process"
	"kill the existing downloader if there is one"
	| doc canPeek front updateCounter |
	UpdateDownloader
		ifNotNil: [UpdateDownloader terminate].
	updateCounter := 0.
	"fork a new downloading process"
	UpdateDownloader := [
		'Downloading updates' displayProgressAt: Sensor cursorPoint from: 0 to: urls size during: [:bar |
			urls
				do: [:url | 
					waitSema wait.
					queue nextPut: url.
					doc := HTTPClient httpGet: url.
					doc isString
						ifTrue: [queue nextPut: #failed.
							UpdateDownloader := nil.
							Processor activeProcess terminate]
						ifFalse: [canPeek := 120 min: doc size.
							front := doc next: canPeek.  doc skip: -1 * canPeek.
							(front beginsWith: '<!DOCTYPE') ifTrue: [
								(front includesSubString: 'Not Found') ifTrue: [
									queue nextPut: #failed.
									UpdateDownloader := nil.
									Processor activeProcess terminate]]].
						UpdateDownloader ifNotNil: [queue nextPut: doc. updateCounter := updateCounter + 1. bar value: updateCounter]]].
			queue nextPut: ''.
			queue nextPut: #finished.
			UpdateDownloader := nil] newProcess.
	UpdateDownloader priority: Processor userInterruptPriority.
	"start the process running"
	UpdateDownloader resume