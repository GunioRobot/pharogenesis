initialize
	| fd pvt |
	originalMap _ IdentityDictionary new.
	stubMap _ IdentityDictionary new.
	locatorMap _ IdentityDictionary new.
	internalStubs _ IdentityDictionary new.
	fd _ ScriptingSystem formDictionary.
	pvt _ ScriptingSystem privateGraphics asSet.
	fd keysAndValuesDo:[:sel :form|
		(pvt includes: sel) ifFalse:[
			internalStubs at: form put:
				(DiskProxy 
					global: #ScriptingSystem
					selector: #formAtKey:extent:depth:
					args: {sel. form extent. form depth})]].