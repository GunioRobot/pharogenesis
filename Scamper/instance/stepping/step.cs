step
	"check if a new document has arrived"
	| results |
	[documentQueue isEmpty] whileFalse: [
		results _ documentQueue next.

		results == #stateDownloaded ifTrue: [ 
			"images and such have been downloaded; update the page"
			self status: 'reformatting page...'.
			formattedPage _ document formattedTextForBrowser: self defaultBaseUrl: currentUrl.
			backgroundColor _ Color fromString: document body bgcolor.
			self changeAll: #(backgroundColor formattedPage).
			self status: 'sittin'. ]
		 ifFalse: [		
			self displayDocument: results 	
		] ]