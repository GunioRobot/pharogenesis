declareModuleName: nameString local: bool
	"add the declaration of a module name, version and local/external tag"

	self var: #moduleName declareC:'const char *moduleName = "', nameString, (bool ifTrue:[' (i)"'] ifFalse:[' (e)"'])

