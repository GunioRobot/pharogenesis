isADBNamed: dbname
	"return whether there is a MailDB on disk with the specified name"
	| status |
	status := self dbStatusFor: dbname.
	^status ~~ #doesNotExist.