verifyMethodCache

	1 to: MethodCacheEntries do: [:index |
		self okayFields: (methodCache at: index + MethodCacheSelectorCol).	"selector"
		self okayFields: (methodCache at: index + MethodCacheClassCol).		"class"
		self okayFields: (methodCache at: index + MethodCacheMethodCol).		"method"
		self okayFields: (methodCache at: index + MethodCacheTMethodCol).	"translated method"
	]