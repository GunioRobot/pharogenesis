moniker
	"a plain language name for this directory"

	moniker ifNil: [
		^ directory first == $/ 
			ifTrue: [server, directory]
			ifFalse: [server, '/', directory]].
	^ moniker