compileEnumerator
	"Compile #nodesDo: for the receiver"
	| varName typeName s |
	s _ WriteStream on: (String new: 100).
	s nextPutAll: 'nodesDo: aBlock'.
	s crtab; nextPutAll:'"This method was automatically generated"'.
	s crtab; nextPutAll:'aBlock value: self.'.
	(self nodeSpec attributes select:[:attr| attr isEvent not]) do:[:attr|
		varName _ (attr name copyReplaceAll:'_' with: '').
		typeName _ attr type.
		(typeName = 'SFNode') ifTrue:[
			s crtab; nextPutAll: varName; nextPutAll:' ifNotNil:['; nextPutAll: varName;
					nextPutAll:' nodesDo: aBlock].'.
		].
		(typeName = 'MFNode') ifTrue:[
			s crtab; nextPutAll: varName; nextPutAll:' ifNotNil:['; nextPutAll: varName;
				nextPutAll:' do:[:doNode| doNode nodesDo: aBlock]].'.
		].
	].
	self compile: s contents classified: 'enumerating'.