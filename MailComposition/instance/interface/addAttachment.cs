addAttachment
	| file fileResult fileName |
	textEditor
		ifNotNil: [self hasUnacceptedEdits ifTrue: [textEditor accept]].

	(fileResult _ StandardFileMenu oldFile)
		ifNotNil: 
			[fileName _ fileResult directory fullNameFor: fileResult name.
			file _ FileStream readOnlyFileNamed: fileName.
			file ifNotNil:
				[file binary.
				self messageText:
						((MailMessage from: self messageText asString)
							addAttachmentFrom: file withName: fileResult name; text).
				file close]] 