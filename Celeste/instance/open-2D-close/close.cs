close
	"Close the mail database."

	self account clearPasswords.
	mailDB ifNotNil: 
			[mailDB close.
			mailDB := nil]