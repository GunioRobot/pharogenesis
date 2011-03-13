createIconMethodsFromDirectory: directory 
	"Create the methods for the icons.
	(self createIconMethodsFromDirectory: '')."
	
	| iconContentsSourceTemplate iconSourceTemplate normalSize smallSize |
	iconContentsSourceTemplate := '{1}IconContents
	"Private - Method generated with the content of the file {2}"
	^ ''{3}'''.
	iconSourceTemplate := '{1}
	"Private - Generated method"
	^icons
			at: #{1}
			ifAbsentPut:[ Form fromBinaryStream: (Base64MimeConverter mimeDecodeToBytes: self {1}Contents readStream) ].'.
	normalSize := self normalSizeNames.
	smallSize := self smallSizeNames.
	normalSize , smallSize
		do: [:each | 
			| png base64 contentsSelector selector | 
			png := directory , each, '.png'.
			[base64 := self base64ContentsOfFileNamed: png.]
				on: Error do: [base64 := nil].
			base64 ifNotNil: [
				contentsSelector := (each , 'IconContents') asSymbol.
				((self respondsTo: contentsSelector)
						and: [(self perform: contentsSelector) = base64])
					ifFalse: [| contentsSource | 
						contentsSource := iconContentsSourceTemplate format: {each. png. base64}.
						self class compile: contentsSource classified: 'private - icons'].
				selector := (each , 'Icon') asSymbol.
				(self respondsTo: selector)
					ifFalse: [| source | 
						source := iconSourceTemplate format: {selector}.
						self class compile: source classified: 'private - icons']]].
	self initializeIcons