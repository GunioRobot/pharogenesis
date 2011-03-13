ma: aUrl
 
	"Set the value of host"

	ma := aUrl last = $/ ifTrue: [ aUrl ] ifFalse: [ aUrl, '/' ]