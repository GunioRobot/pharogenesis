importIntoCategory
	"Add the messages from a Unix or Eudora format file into this category"

	| inboxPath count |
	mailDB ifNil: [ ^self ].
	self category ifNil: [ ^self ].

	"get the file to import from"
	inboxPath _ ''.
	[	inboxPath _ FillInTheBlank request: 'file to import from?\(should be Eudora or Unix format)' withCRs.
		inboxPath isEmpty ifTrue: [ ^self ].
		FileStream isAFileNamed: inboxPath 
	] whileFalse: [
		self inform: 'file does not exist' ].

	Utilities informUser: 'Fetching mail from ', inboxPath during: [
		count _ mailDB importMailFrom: inboxPath  intoCategory: self category. ].
	self inform: count printString, ' messages imported'.

	self updateTOC.