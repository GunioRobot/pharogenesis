generate: pageRef
	"Generate the page to the serverDirectory. Use the render.html page as a template"

	| formattedPage renderedFile newmap file|
	"Make a copy, then format the text."
	formattedPage _ pageRef copy.
	newmap _ urlmap copy.		" Create a new action with different action for cached form."
	newmap action: (RendererSwikiAction new).
	newmap action name: '.'.
	formattedPage formatted: (formatter swikify: pageRef text
			linkhandler: [:link | newmap
					linkFor: link
					from: 'Nowhere'
					storingTo: OrderedCollection new]).
	(serverDirectory isKindOf: String)
	ifTrue: [ "Just save the file into the directory"
		renderedFile _ (serverDirectory),(pageRef coreID),'.html'.
		(StandardFileStream isAFileNamed: renderedFile)
			ifTrue: [FileDirectory deleteFilePath: renderedFile].
		file _ FileStream fileNamed: renderedFile.
		file nextPutAll: (HTMLformatter evalEmbedded: (self fileContents: source ,'render.html')
								with: formattedPage).
		file close.]
	ifFalse: [ "Assume it's FTP and send it off"
		renderedFile _ (pageRef coreID),'.html'.
		(StandardFileStream isAFileNamed: renderedFile)
			ifTrue: [FileDirectory deleteFilePath: renderedFile].
		file _ FileStream fileNamed: renderedFile.
		file nextPutAll: (HTMLformatter evalEmbedded: (self fileContents: source ,'render.html')
								with: formattedPage).
		file close.
		serverDirectory putFile: (FileStream fileNamed: renderedFile) named: renderedFile.
		"FileDirectory deleteFilePath: renderedFile"]