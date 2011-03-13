generate: pageRef from: request
	"Just reply with a page in HTML format"

	| formattedPage peer cacheFile file|
	(request isKindOf: PWS) 
	ifFalse: [(request isKindOf: String) ifTrue: [peer _ request] ifFalse: [peer _ ' ']] 
	ifTrue: [peer _ request peerName].
	formattedPage _ pageRef copy.
	"Make a copy, then format the text."
	formattedPage formatted: (HTMLformatter swikify: pageRef text
			linkhandler: [:link | urlmap
					linkForCache: link
					from: peer
					storingTo: OrderedCollection new]).
	cacheFile _ (self cacheDirectory),(self name),(ServerAction pathSeparator),(pageRef coreID),'.html'.
	(StandardFileStream isAFileNamed: cacheFile)
	ifTrue: [FileDirectory deleteFilePath: cacheFile].
	file _ FileStream fileNamed: cacheFile.
	file nextPutAll: (HTMLformatter evalEmbedded: (self fileContents: source ,'page.html')
			with: formattedPage).
	file close.

