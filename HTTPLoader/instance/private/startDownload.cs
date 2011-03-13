startDownload
	| newDownloadProcess |
	(downloads size < self maxNrOfConnections 
		and: [requests size > 0]) ifTrue: [
			newDownloadProcess _ [
				self flag: #httpLoader log: 'Starting download'.
				self nextRequest startRetrieval.
				self flag: #httpLoader log: 'Download done'.
				downloads remove: Processor activeProcess.
				self startDownload] newProcess.
			downloads add: newDownloadProcess.
			newDownloadProcess resume]