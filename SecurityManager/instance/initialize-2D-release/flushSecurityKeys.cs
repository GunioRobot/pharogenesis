flushSecurityKeys
	"Flush all keys"
	privateKeyPair ifNotNil:[
		self flushSecurityKey: privateKeyPair first.
		self flushSecurityKey: privateKeyPair last.
	].
	privateKeyPair _ nil.
	trustedKeys do:[:key| self flushSecurityKey: key].
	trustedKeys _ #().