decompileClass: aClass selector: selector
	"Return the decompiled parse tree that represents self"

	^ self decompilerClass new decompile: selector in: aClass method: self