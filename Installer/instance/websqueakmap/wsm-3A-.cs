wsm: aUrl
 
	"Set the value of host"

	wsm := aUrl last = $/ ifTrue: [ aUrl ] ifFalse: [ aUrl, '/' ]