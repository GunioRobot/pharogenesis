mc: aUrl
 
	"Set the value of host"

	mc := aUrl last = $/ ifTrue: [ aUrl ] ifFalse: [ aUrl, '/' ]