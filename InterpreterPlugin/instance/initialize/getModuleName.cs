getModuleName
	"Note: This is hardcoded so it can be run from Squeak.
	The module name is used for validating a module *after*
	it is loaded to check if it does really contain the module
	we're thinking it contains. This is important!"
	self returnTypeC:'const char*'.
	self export: true.
	^moduleName