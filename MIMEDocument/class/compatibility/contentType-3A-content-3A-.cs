contentType: aString  content: content
	"create a MIMEObject with the given content-type and content"
	"MIMEObject contentType: 'text/plain' content: 'This is a test'"
	
	| ans idx |
	ans := self new.
	ans privateContent: content.

	"parse the content-type"
	(aString isNil or: [
		idx := aString indexOf: $/.
		idx = 0]) 
	ifTrue: [ 
		ans type: (MIMEType main: 'application' sub: 'octet-stream')]
	ifFalse: [ 
		ans type: (MIMEType main: (aString copyFrom: 1 to: idx-1) sub: (aString copyFrom: idx+1 to: aString size))].

	^ans
