currentPackages
	"ScriptLoader new currentPackages" 
	
	
	| copies |
	copies := MCWorkingCopy allManagers asSortedCollection:
		[ :a :b | a package name <= b package name ].
	^ copies select: [:each | '*Plus*' match: each package name ].