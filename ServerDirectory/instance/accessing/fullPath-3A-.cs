fullPath: serverAndDirectory
	"Parse and save a full path.  Convention:  if ftp://user@server/dir, then dir is relative to user's directory.  dir has no slash at beginning.  If ftp://server/dir, then dir is absolute to top of machine, give dir a slash at the beginning."

	| start bare sz userAndServer both slash score match best sd |
	bare _ serverAndDirectory.
	sz _ serverAndDirectory size.
	bare size > 0 ifTrue: [ 
		start _ (bare copyFrom: 1 to: (8 min: sz)) asLowercase.
		(start beginsWith: 'ftp:') 
			ifTrue: [type _ #ftp.
				bare _ bare copyFrom: (7 min: sz) to: bare size].
		(start beginsWith: 'http:') 
			ifTrue: [type _ #http.
				bare _ bare copyFrom: (8 min: sz) to: serverAndDirectory size].
		((start beginsWith: 'file:') or: [type == #file])
			ifTrue: [type _ #file.
				urlObject _ FileUrl absoluteFromText: serverAndDirectory.
				^ self]].
	userAndServer _ bare copyUpTo: self pathNameDelimiter.
	both _ userAndServer findTokens: '@'.
	slash _ both size.	"absolute = 1, relative = 2"
	server _ both last.
	both size > 1 ifTrue: [user _ both at: 1].
	bare size > (userAndServer size + 1) 
		ifTrue: [directory _ bare copyFrom: userAndServer size + slash to: bare size]
		ifFalse: [directory _ ''].

	"If this server is already known, copy in its userName and password"
	type == #ftp ifFalse: [^ self].
	score _ -1.
	ServerDirectory serverNames do: [:name |
		sd _ ServerDirectory serverNamed: name.
		server = sd server ifTrue: [
			match _ directory asLowercase charactersExactlyMatching: sd directory asLowercase.
			match > score ifTrue: [score _ match.  best _ sd]]].
	best 
		ifNil: [self fromUser]
		ifNotNil: [user _ best user.  self password: best password].
