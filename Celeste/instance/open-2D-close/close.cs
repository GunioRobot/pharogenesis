close
	"Close the mail database."

	userPassword _ nil.
	mailDB ifNotNil: [
		mailDB close; release.
		mailDB _ nil].
