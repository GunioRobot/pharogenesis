serverList
	| servers server |
	"Take my list of server URLs and return a list of ServerDirectories to write on."

	urlList isEmptyOrNil ifTrue: [^ nil].
	servers _ OrderedCollection new.
	urlList do: [:url |
		server _ ServerDirectory serverForURL: url.
		server ifNotNil: [servers add: server].
		server _ ServerDirectory serverForURL: url asUrl downloadUrl.
		server ifNotNil: [servers add: server]].
	^servers isEmpty
		ifTrue: [nil]
		ifFalse: [servers]