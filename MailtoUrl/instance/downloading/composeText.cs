composeText
	"Answer the template for a new message."

	^ String streamContents: [:str |
		str nextPutAll: 'From: '.
		str nextPutAll: Celeste userName; cr.
		str nextPutAll: 'To: '.
		str nextPutAll: locator asString; cr.

		str nextPutAll: 'Subject: '; cr.

		Celeste ccList isEmpty ifFalse: [
			str nextPutAll: 'Cc: '.
			str nextPutAll: Celeste ccList; cr].
		str cr].