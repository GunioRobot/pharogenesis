loadImagesIntoBook
	"PowerPoint stores GIF presentations as individual slides named Slide1, Slide2, etc.
	Load these into the book.  mjg 9/99"

	| directory filenumber form newpage |
	directory _ ((StandardFileMenu oldFileFrom: FileDirectory default) ifNil: [^ nil]) directory.
	directory isNil ifTrue: [^ nil].

	"Start loading 'em up!"
	filenumber _ 1.
	[directory fileExists: 'Slide',(filenumber asString)] whileTrue:
		[Transcript show: 'Slide',(filenumber asString); cr.
		(Smalltalk bytesLeft < 1000000) ifTrue: ["Make some room"
			(self valueOfProperty: #url) == nil ifTrue:
				[self savePagesOnURL]
			ifFalse: [self saveAsNumberedURLs].].
		form _ Form fromFileNamed: 
			(directory fullNameFor: 'Slide', (filenumber asString)).
		newpage _ PasteUpMorph new extent: (form extent).
		newpage addMorph: (SketchMorph withForm: form).
		self pages addLast: newpage.
		filenumber _ filenumber + 1.].

	"After adding all, delete the first page."
	self goToPage: 1.
	self deletePageBasic.

	"Save the book"
	(self valueOfProperty: #url) == nil ifTrue:
				[self savePagesOnURL]
			ifFalse: [self saveAsNumberedURLs].