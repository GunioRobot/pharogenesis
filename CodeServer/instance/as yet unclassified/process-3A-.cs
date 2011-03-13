process: request
	"Return the source code from Smalltalk, as text or as a chunk.
URLs are of this form.  Each may have 'chunk' or 'smtlk' as the thing after the slash
	machine:80/smtlk.Point|min;
	machine:80/chunk.{Class}|{selector}		
	machine:80/smtlk.{Class}|{selector}
	machine:80/smtlk.{Class}|class|{selector}
	machine:80/smtlk.{Class}|Definition
	machine:80/smtlk.{Class}|Hierarchy
	machine:80/smtlk.{Class}|Comment
NOTE: use ; semicolon instead of : colon in selector names!!!"

	| coreRef |
	coreRef _ (request message at: 1) asLowercase.
	request reply: PWS success; reply: PWS contentHTML.
	Transcript show: 'In process: ', request message printString; cr.
	coreRef = 'smtlk' ifTrue: [^ self smtlk: request].
	coreRef = 'chunk' ifTrue: [^ self chunk: request].
	request reply: ( 'HTTP/1.0 400 Bad Request', PWS crlfcrlf, 
		'expected smtlk.{Class}|{selector} or chunk.{Class}|{selector}').	"failure"