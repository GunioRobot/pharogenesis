primitiveSetMaterial
	| material handle |
	self export: true.
	self inline: false.
	self var: #material type: 'void*'.

	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].
	material _ self stackMaterialValue: 0.
	handle _ interpreterProxy stackIntegerValue: 1.
	(self cCode:'b3dxLoadMaterial(handle, material)' inSmalltalk:[false])
		ifFalse:[^interpreterProxy primitiveFail].
	^interpreterProxy pop: 2. "args; return rcvr"