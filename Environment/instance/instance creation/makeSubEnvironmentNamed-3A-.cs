makeSubEnvironmentNamed: name
	"Make a new environment (with its own class) of the given name.
	Install it under that name in this environment, and point its outerEnvt link here as well."
	| envtClass envt |
	envtClass _ self class subclass: (name , 'Environment') asSymbol
				instanceVariableNames: '' classVariableNames: ''
				poolDictionaries: '' category: 'System-Environments'.
	envt _ envtClass new setName: name inOuterEnvt: self.
	envtClass addSharedPool: envt.  "add it to its own compilation context for exports"
	^ envt