offerBookishMenu
	"Offer a menu with book-related items in it"

	| aMenu |
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: 'Stack / Book'.
	aMenu addStayUpItem.
	aMenu addList:
		#(('sort pages'			sortPages)
		('uncache page sorter'	uncachePageSorter)).
	(self hasProperty: #dontWrapAtEnd)
		ifTrue: [aMenu add: 'wrap after last page' selector: #setWrapPages: argument: true]
		ifFalse: [aMenu add: 'stop at last page' selector: #setWrapPages: argument: false].
	aMenu addList:
		#(('make bookmark'		bookmarkForThisPage)
		('make thumbnail'		thumbnailForThisPage)).

	aMenu addLine.
	aMenu add: 'sound effect for all pages' action: #menuPageSoundForAll:.
	aMenu add: 'sound effect this page only' action: #menuPageSoundForThisPage:.
	aMenu add: 'visual effect for all pages' action: #menuPageVisualForAll:.
	aMenu add: 'visual effect this page only' action: #menuPageVisualForThisPage:.

	aMenu addLine.
	(self primaryHand pasteBuffer class isKindOf: PasteUpMorph class) ifTrue:
		[aMenu add: 'paste book page'   action: #pasteBookPage].

	aMenu add: 'save as new-page prototype' action: #setNewPagePrototype.
	newPagePrototype ifNotNil: [
		aMenu add: 'clear new-page prototype' action: #clearNewPagePrototype].

	aMenu add: (self dragNDropEnabled ifTrue: ['close'] ifFalse: ['open']) , ' dragNdrop'
			action: #toggleDragNDrop.
	aMenu add: 'make all pages this size' action: #makeUniformPageSize.
	aMenu add: 'send all pages to server' action: #savePagesOnURL.
	aMenu add: 'send this page to server' action: #saveOneOnURL.
	aMenu add: 'reload all from server' action: #reload.
	aMenu add: 'copy page url to clipboard' action: #copyUrl.
	aMenu add: 'keep in one file' action: #keepTogether.

	aMenu addLine.
	aMenu add: 'load PPT images from slide #1' action: #loadImagesIntoBook.
	aMenu add: 'background color for all pages...' action: #setPageColor.

	aMenu popUpEvent: self world activeHand lastEvent in: self world


