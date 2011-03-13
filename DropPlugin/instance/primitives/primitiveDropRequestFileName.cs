primitiveDropRequestFileName
	"Note: File handle creation needs to be handled by specific support code explicitly bypassing the plugin file sand box."
	| dropIndex dropName nameLength nameOop namePtr |
	self export: true.
	self inline: false.
	self var: #dropName type: 'char *'.
	self var: #namePtr type: 'char *'.
	interpreterProxy methodArgumentCount = 1 
		ifFalse:[^interpreterProxy primitiveFail].
	dropIndex _ interpreterProxy stackIntegerValue: 0.
	dropName _ self dropRequestFileName: dropIndex.
	"dropRequestFileName returns name or NULL on error"
	dropName == nil 
		ifTrue:[^interpreterProxy primitiveFail].
	nameLength _ self strlen: dropName.
	nameOop _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: nameLength.
	namePtr _ interpreterProxy firstIndexableField: nameOop.
	0 to: nameLength-1 do:[:i| namePtr at: i put: (dropName at: i)].
	interpreterProxy pop: 2.
	interpreterProxy push: nameOop.
