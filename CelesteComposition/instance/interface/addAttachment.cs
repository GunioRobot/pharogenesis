addAttachment
	| file fileResult fileName |
	textEditor
		ifNotNil: [self hasUnacceptedEdits ifTrue: [textEditor accept]].
	"transform into multipart if needed"
	self hasAttachments ifFalse: [self transformToMultipart].
	"then simply append another attachment section"
	(fileResult _ StandardFileMenu oldFile)
		ifNotNil: 
			[fileName _ fileResult directory fullNameFor: fileResult name.
			file _ FileStream readOnlyFileNamed: fileName.
			file ifNotNil: [self messageText: ((MailMessage from: self messageText)
						asTextEncodingNewPart: file named: fileResult name)]] 