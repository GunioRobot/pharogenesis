restore: nameOfSwiki
	"Read all files in the directory 'nameOfSwiki'.  Reconstruct the url map."

	super restore: nameOfSwiki.
	authorizer _ Authorizer new.	"<- not restored from disk in this implementation"
	authorizer realm: name.
