decompileClass: aClass selector: selector
	"Return the decompiled parse tree that represents self"

	self deprecated: 'just call #decompile on the CompiledMethod'.
	^ self decompilerClass new decompile: selector in: aClass method: self