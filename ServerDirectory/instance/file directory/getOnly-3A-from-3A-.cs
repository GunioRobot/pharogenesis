getOnly: nnn from: fileNameOnServer
	| file ff resp |
	"Use FTP to just capture the first nnn characters of the file.  Break the connection after that.  Goes faster for long files.  Return the contents, not a stream."

	type == #file ifTrue: [
		file _ self as: ServerFile.
		file fileName: fileNameOnServer.
		ff _ FileStream oldFileOrNoneNamed: (file fileNameRelativeTo: self).
		^ ff next: nnn].
	type == #http ifTrue: [
		resp _ HTTPSocket httpGet: (self fullNameFor: fileNameOnServer) 
				accept: 'application/octet-stream'.
			"For now, get the whole file.  This branch not used often."
		^ resp truncateTo: nnn].
	
	^ self getOnlyBuffer: (String new: nnn) from: fileNameOnServer