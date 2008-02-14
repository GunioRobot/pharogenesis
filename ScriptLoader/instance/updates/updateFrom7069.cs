updateFrom7069
	"self new updateFrom7069"
	

	"unloading OB"	
	(MCWorkingCopy forPackage: (MCPackage new name: 'OmniBrowser')) unload.
	(MCWorkingCopy forPackage: (MCPackage new name: 'OB-Standard')) unload.
	SystemBrowser removeObsolete.
	SystemOrganization removeCategoriesMatching: 'OmniBrowser*'.
	SystemOrganization removeCategoriesMatching: 'OB-Standard*'.
	
	World setModel: MorphicModel new.
	Behavior flushObsoleteSubclasses.
	Smalltalk cleanOutUndeclared.
	self flushCaches.
	
	
	
	