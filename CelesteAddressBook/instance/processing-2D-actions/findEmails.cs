findEmails
	"Process the emails. In the future I will have a child process doing this"
	mutex
		critical: [self findEmailsProcess].
		