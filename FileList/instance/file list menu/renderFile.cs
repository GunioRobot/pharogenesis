renderFile
	"Render the currently selected file"
	| map action file renderedFile formatPage |
	listIndex = 0 ifTrue: [^ self].
	map _ URLmap new.
	action _ RenderedSwikiAction new.
	action name: '.'.  "For image references, refer to this directory"
	map action: action.
	map directory: directory.
	(directory fileExists: 'glossary')
	ifFalse: [Cursor wait showWhile: [
		(directory newFileNamed: 'glossary') close].].
	map readGlossary: (directory oldFileNamed: 'glossary').
	formatPage _ SwikiPage new.
	formatPage map: map.
	formatPage coreID: (fileName allButFirst).
	formatPage formatted: (HTMLformatter
		evalEmbedded: (directory oldFileNamed: fileName)
contentsOfEntireFile
		with: formatPage
		unlessContains: (Set new)).
	formatPage name isNil
		ifTrue: [self notify: 'You forgot to name the page!
<?request name: ''myname''?>'.
				formatPage name: 'defaultName'.].
	map pages at: (formatPage name asLowercase) put: formatPage.
	formatPage formatted: (LessHTMLformatter swikify: (formatPage
formatted)
			linkhandler: [:link | map
					linkFor: link
					from: 'Nowhere'
					storingTo: OrderedCollection new]).
	"Make a template if one does not exist"
	(directory fileExists: 'template.html')
	ifFalse: [Cursor wait showWhile: [
		(directory newFileNamed: 'template.html') nextPutAll: (self
templateFile); close].].
	renderedFile _ (directory pathName),(ServerAction
pathSeparator),(formatPage coreID).
	(directory fileExists: renderedFile)
		ifTrue: [directory deleteFileNamed: renderedFile].
	file _ FileStream fileNamed: renderedFile.
	file nextPutAll: (HTMLformatter evalEmbedded:
		(directory oldFileNamed: 'template.html') contentsOfEntireFile
			with: formatPage).
	file close.
	FileDirectory default setMacFileNamed: renderedFile
		type: 'TEXT'
		creator: 'MOSS'.
	map writeGlossary. "Directory is already in the map, so write to
the glossary there"
	self updateFileList.
