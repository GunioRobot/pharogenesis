composeText
	"Answer the template for a new message."

	^ String streamContents: [:str |
		str nextPutAll: 'From: '.
		str nextPutAll: self account userName; cr.

		str nextPutAll: 'To: '; cr.
		str nextPutAll: 'Subject: '; cr.

		self account ccList isEmpty ifFalse: [
			str nextPutAll: 'Cc: '.
			str nextPutAll: self account ccList; cr].
		str cr].
