addAttachment
	| file fileResult fileName |
	textEditor
		ifNotNil: [self hasUnacceptedEdits ifTrue: [textEditor accept]].

	(fileResult := StandardFileMenu oldFile)
		ifNotNil: 
			[fileName := fileResult directory fullNameFor: fileResult name.
			file := FileStream readOnlyFileNamed: fileName.
			file ifNotNil:
				[file binary.
				self messageText:
						((MailMessage from: self messageText asString)
							addAttachmentFrom: file withName: fileResult name; text).
				file close]] 