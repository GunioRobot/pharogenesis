sendMailMessage: aMailMessage
	| newComposition |
	newComposition _ self new.
	newComposition messageText: aMailMessage text; open