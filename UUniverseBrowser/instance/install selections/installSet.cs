installSet
	^installSet ifNil: [ installSet :=
		UGlobalInstaller universe: universe configuration: configuration
	]