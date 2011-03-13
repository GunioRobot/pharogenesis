translateIt
	| aWord |
	"Translate a passage of text and open its definition in a separate window.  Use the FreeTranslation.com server.  Requires internet access.  Default is English-> Spanish, but set it with the 'choose language' menu item."

	self lineSelectAndEmptyCheck: [^ self].
	aWord _ self selection asString.
	self terminateAndInitializeAround: [
		FreeTranslation openScamperOn: aWord].


