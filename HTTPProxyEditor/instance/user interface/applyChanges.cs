applyChanges
	"apply the changes on HTTPSocket"
	| finalServerName finalPort |
	finalServerName := serverName asString withBlanksTrimmed.
	[finalPort := port asString withBlanksTrimmed asNumber]
		on: Error
		do: [:ex | finalPort := 0].
	""
	(finalServerName isNil
			or: [finalServerName isEmpty]
			or: [finalPort isZero])
		ifTrue: [""
Transcript
		show: ('Stop using Proxy Server.' translated );
		 cr.
""
			HTTPSocket stopUsingProxyServer.
			^ self].
	""
	Transcript
		show: ('Proxy Server Named: ''{1}'' port: {2}.' translated format: {finalServerName. finalPort});
		 cr.
	HTTPSocket useProxyServerNamed: finalServerName port: finalPort