checkAuthorization: webDocument retry: retryBlock
	"authorization failed if webDocument is a String"
	| oldRealm i end encoded |
	((webDocument isString)
		and: [(webDocument beginsWith: 'HTTP/1.0 401')
			or: [webDocument beginsWith: 'HTTP/1.1 401']])
	ifFalse: [^self].

	oldRealm _ realm.
	i _ webDocument findString: 'realm="'.
	i = 0 ifTrue: [^self].
	end _ webDocument indexOf: $" startingAt: i.
	realm _ webDocument copyFrom: i+7 to: end.
	"realm _ (webDocument findTokens: '""') at: 2."
	Passwords ifNil: [Passwords _ Dictionary new].
	encoded _ Passwords at: realm ifAbsent: [nil].
	(oldRealm ~= realm) & (encoded ~~ nil) 
		ifTrue: [^ retryBlock value]
		ifFalse: ["ask the user"
			self askNamePassword ifTrue: [^ retryBlock value]]