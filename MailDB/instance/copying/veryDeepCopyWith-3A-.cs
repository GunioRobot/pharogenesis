veryDeepCopyWith: deepCopier
	"don't copy MailDB's -- they refer to external state in files, and the user almost certainly does not intend for a completely independent MailDB to be created"
	^self