compileAccessors
	"Compile all accessors for the receiver"
	| varName typeName |
	(self nodeSpec attributes select:[:attr| attr isEvent not]) do:[:attr|
		varName _ (attr name copyReplaceAll:'_' with: '').
		typeName _ (attr type copyReplaceAll:'_' with: '').
		typeName first isUppercase ifFalse:[
			typeName _ typeName first asUppercase asString, 
				(typeName copyFrom: 2 to: typeName size)].
		self compile:(String streamContents:[:s|
			s nextPutAll: varName; crtab.
			s nextPutAll: '"This is an automatically generated accessor"'; crtab.
			s nextPutAll:'^'; nextPutAll: varName])
			classified: 'accessing'.
		self compile: (String streamContents:[:s|
			s nextPutAll: varName; nextPutAll:': a'; nextPutAll: typeName; crtab.
			s nextPutAll: '"This is an automatically generated accessor"'; crtab.
			(attr isExposedField and:[attr isSingleField]) ifTrue:[
				s nextPutAll: varName; nextPutAll:' = a'; nextPutAll: typeName; 
					nextPutAll:' ifFalse:['; crtab: 2].
			s nextPutAll: varName; nextPutAll:' := a'; nextPutAll: typeName; nextPutAll:'.'.
			attr isExposedField ifTrue:[
				s crtab.
				attr isSingleField ifTrue:[s tab].
				s nextPutAll: 'self trigger: #'; print: (attr name,'_changed');
						nextPutAll: ' with: '; nextPutAll: varName.
				attr isSingleField ifTrue:[s nextPutAll:']']]])
			classified: 'accessing'.
	].
