newProviderFor: packageName
	| cls clsName |
	clsName := ((packageName copyWithout: $-) , 'ServiceProvider') asSymbol.
	cls := self subclass: clsName
		instanceVariableNames: '' 
		classVariableNames: '' 
		poolDictionaries: ''
		category: packageName.
	cls class compile: 'initialize 
	ServiceRegistry buildProvider: self new' classified: 'initialization'.
	^ cls