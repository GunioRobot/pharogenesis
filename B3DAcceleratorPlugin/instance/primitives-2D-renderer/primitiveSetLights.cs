primitiveSetLights
	| lightArray lightCount light handle |
	self export: true.
	self inline: false.
	self var: #light type: 'void*'.

	interpreterProxy methodArgumentCount = 2
		ifFalse:[^interpreterProxy primitiveFail].

	lightArray _ self stackLightArrayValue: 0.
	handle _ interpreterProxy stackIntegerValue: 1.
	interpreterProxy failed ifTrue:[^nil].
	(self b3dxDisableLights: handle)
		ifFalse:[^interpreterProxy primitiveFail].
	lightArray == nil ifTrue:[^nil].
	lightCount _ interpreterProxy slotSizeOf: lightArray.
	"For each enabled light source"
	0 to: lightCount-1 do:[:i|
		light _ self fetchLightSource: i ofObject: lightArray.
		(self cCode:'b3dxLoadLight(handle, i, light)' inSmalltalk:[false])
			ifFalse:[^interpreterProxy primitiveFail].
	].
	^interpreterProxy pop: 2. "args; return rcvr"