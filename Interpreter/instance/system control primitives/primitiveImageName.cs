primitiveImageName
	"When called with a single string argument, record the string as the current image file name. When called with zero arguments, return a string containing the current image file name."
	| s sz sCRIfn okToRename |
	argumentCount = 1
		ifTrue: ["If the security plugin can be loaded, use it to check for rename permission. 
			If not, assume it's ok"
			sCRIfn := self ioLoadFunction: 'secCanRenameImage' From: 'SecurityPlugin'.
			sCRIfn ~= 0
				ifTrue: [okToRename := self cCode: ' ((int (*) (void)) sCRIfn)()'.
					okToRename ifFalse: [^ self primitiveFail]].
			"Make sure the arg is a plausible String"
			s := self stackTop.
			(self isBytes: s)
				ifFalse: [^ self primitiveFail].
			successFlag
				ifTrue: [sz := self stSizeOf: s.
					"if the image name is not accepted by the VM support code, fail"
					(self imageNamePut: s + BaseHeaderSize Length: sz) = 0
						ifTrue: [^ self primitiveFail].
					self pop: 1]]

		ifFalse: ["Just return the imageName"
			sz := self imageNameSize.
			s := self
					instantiateClass: (self splObj: ClassString)
					indexableSize: sz.
			self imageNameGet: s + BaseHeaderSize Length: sz.
			self pop: 1 thenPush: s]