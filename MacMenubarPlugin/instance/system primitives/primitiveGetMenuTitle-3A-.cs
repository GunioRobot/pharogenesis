primitiveGetMenuTitle: menuHandleOop
	| menuHandle size oop ptr aString |
	self primitive: 'primitiveGetMenuTitle'
		parameters: #(Oop).
	self var: 'menuHandle' type: 'MenuHandle'.
	self var: #aString declareC: 'Str255 aString'.
	self var: #ptr type: 'char *'.
	
	menuHandle := self cCoerce: (interpreterProxy positive32BitValueOf: menuHandleOop) to: 'MenuHandle'.
	(self ioCheckMenuHandle: menuHandle) ifFalse: [^interpreterProxy success: false].
	aString at: 0 put: 0.
	self cCode: 'GetMenuTitle(menuHandle,aString)' inSmalltalk:[menuHandle].
	size := self cCode: 'aString[0]' inSmalltalk: [0].
	oop _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize:  size.
	ptr _ interpreterProxy firstIndexableField: oop.
	0 to: size-1 do:[:i|
		ptr at: i put: (aString at: (i+1))].
	^oop

