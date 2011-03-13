saveIndexOnURL
	"Make up an index to the pages of this book, with thumbnails, and store it on the server.  (aDictionary, aMorphObjectOut, aMorphObjectOut, aMorphObjectOut).  The last part corresponds exactly to what pages looks like when they are all out.  Each holds onto a SqueakPage, which holds a url and a thumbnail."

	| dict list mine sf remoteFile urlList |
	pages size = 0 ifTrue: [^ self].
	dict _ Dictionary new.  dict at: #modTime put: Time totalSeconds.
	"self getAllText MUST have been called at start of this operation."
	dict at: #allText put: (self valueOfProperty: #allText).
	#(color borderWidth borderColor pageSize) do: [:sel |
		dict at: sel put: (self perform: sel)].

	self reserveUrlsIfNeeded.	"should already be done"
	list _ pages copy.	"paste dict on front below"
	"Fix up the entries, should already be done"
	list doWithIndex: [:out :ind |
		out isInMemory ifTrue: [  
			(out valueOfProperty: #SqueakPage) ifNil: [
				out saveOnURLbasic].
			list at: ind put: (out sqkPage copyForSaving)]].
	urlList _ list collect: [:ppg | ppg url].
	self setProperty: #allTextUrls toValue: urlList.
	dict at: #allTextUrls put: urlList.
	list _ (Array with: dict), list.
	mine _ self valueOfProperty: #url.
	mine ifNil: [mine _ self getStemUrl, '.bo'.
		self setProperty: #url toValue: mine].
	sf _ ServerDirectory new fullPath: mine.
	Cursor wait showWhile: [
		remoteFile _ sf fileNamed: mine.
			remoteFile dataIsValid.
		remoteFile fileOutClass: nil andObject: list.
		"remoteFile close"].
