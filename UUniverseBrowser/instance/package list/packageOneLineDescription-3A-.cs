packageOneLineDescription: p 
	| commentary |
	p isUPackage ifFalse: [ ^p printString ].
	commentary := ''.
	(self installSet isPackageVersionSelected: p) ifTrue: [commentary := '(to install) '].
	(configuration includesPackageSpec: p packageSpec) 
		ifTrue: [commentary := '(installed) '].
	^ commentary , p printString
