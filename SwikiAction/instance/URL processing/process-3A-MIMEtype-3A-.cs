process: request MIMEtype: imageGif
	"See if there is a .gif file on my disk of this name, and send it out."

	| fName |
	fName _ ServerAction serverDirectory, (request message at: 1), 
		':', (request message at: 2).
	3 to: request message size do: [:part |
		fName _ fName, '.', (request message at: part)].
	Transcript show: fName; cr.
	(FileDirectory default fileExists: fName) 
		ifTrue: [
			request reply: (PWS success),(PWS content: imageGif), PWS crlf.
			request reply: (FileStream oldFileNamed: fName) contentsOfEntireFile]
		ifFalse: [
			request reply: ( 'HTTP/1.0 400 Bad Request', PWS crlfcrlf, 'file not found')].
