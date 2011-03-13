getPackageProvider
	| provs classes |
	provs := ServiceProvider registeredProviders.
	classes := self getPackage classes.
	^ classes detect: [:e | provs includes: e] ifNone: [ServiceProvider newProviderFor: self getPackageName]