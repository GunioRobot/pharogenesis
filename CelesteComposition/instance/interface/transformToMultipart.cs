transformToMultipart
	| oldPart |
	oldPart _ MailMessage from: self messageText asString.
	self messageText: oldPart asMultipartText

	