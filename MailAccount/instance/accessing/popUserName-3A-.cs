popUserName: x
	self clearPasswords.
	"be kind, if they include the host name here"
	popUserName _ x copyUpTo: $@.
