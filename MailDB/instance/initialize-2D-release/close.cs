close
	"Close up the database in preparation for closing celeste"

	self saveDB; saveTokens.
	messageFile ifNotNil: [messageFile close].
