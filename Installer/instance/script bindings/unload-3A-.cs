unload: categoryMatchesString 

 (SystemOrganization categoriesMatching: categoryMatchesString) do: [ :cat | 
     self logCR: 'Unloading ', cat.
 	(MCPackage named: cat)  workingCopy unload.
	SystemOrganization removeCategory: cat.
 ].

"Until Mantis 5718 is addressed"
 Smalltalk at: #PackagePaneBrowser ifPresent: [ :ppbClass | ppbClass allInstancesDo: [ :ppb | ppb updatePackages ]  ].
 Smalltalk at: #Browser ifPresent: [ :bClass | bClass allInstancesDo: [ :b | b updateSystemCategories ] ].