primitiveSetBitBltPlugin
	"Primitive. Set the BitBlt plugin to use."
	| pluginName length ptr needReload |
	self export: true.
	self var: #ptr declareC:'char *ptr'.
	pluginName _ interpreterProxy stackValue: 0.
	"Must be string to work"
	(interpreterProxy isBytes: pluginName) 
		ifFalse:[^interpreterProxy primitiveFail].
	length _ interpreterProxy byteSizeOf: pluginName.
	length >= 256 
		ifTrue:[^interpreterProxy primitiveFail].
	ptr _ interpreterProxy firstIndexableField: pluginName.
	needReload _ false.
	0 to: length-1 do:[:i|
		"Compare and store the plugin to be used"
		(bbPluginName at: i) = (ptr at: i) ifFalse:[
			bbPluginName at: i put: (ptr at: i).
			needReload _ true]].
	(bbPluginName at: length) = 0 ifFalse:[
		bbPluginName at: length put: 0.
		needReload _ true].
	needReload ifTrue:[
		self initialiseModule 
			ifFalse:[^interpreterProxy primitiveFail]].
	interpreterProxy pop: 1. "Return receiver"