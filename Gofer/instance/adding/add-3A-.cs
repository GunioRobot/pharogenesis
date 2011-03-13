add: aReference
	"Add aReference to the list of packages."
	
	^ aReference isString 
		ifTrue: [ self notify: 'Please note that adding package references as strings (such as ' , aReference printString , ') is no longer supported, because Gofer cannot guess your naming conventions. Adapt your code to either call #addPackage: (for full package names, e.g. ''Gofer''), #addVersion: (for complete version names, e.g. ''Gofer-lr.54'') or #addQuery:do: (for full package names, e.g. ''Gofer'', with the possiblity to add additional conditions, e.g. reference author: ''lr''; branch: ''super''). This lets Gofer know what exactly you want, and in return it will more likely do what you expect.' ]
		ifFalse: [ self references addLast: aReference ]