url
	| vv serv |
	"compose my url on the server"

	vv _ version.
	version ifNil: [vv _ 'AA'].
	urlList ifNotNil: [urlList size > 0 ifTrue: [
		serv _ urlList first last == $/ ifTrue: [urlList first] ifFalse: [urlList first, '/'].
		^ serv, self name,'|',vv,'.pr']].
	^ ''