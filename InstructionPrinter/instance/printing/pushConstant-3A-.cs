pushConstant: obj
	"Print the Push Constant, obj, on Top Of Stack bytecode."

	self print: 'pushConstant: ' , (String streamContents: [:s |
		(obj isKindOf: LookupKey)
			ifFalse: [s withStyleFor: #literal do: [obj printOn: s]]
			ifTrue: [obj key
				ifNotNil: [s nextPutAll: '##'; nextPutAll: obj key]
				ifNil: [s nextPutAll: '###'; nextPutAll: obj value soleInstance name]]
	]).

	(obj isKindOf: CompiledMethod) ifTrue: [
		obj longPrintOn: stream indent: self indent + 2. ^ self].
	Smalltalk at: #BlockClosure ifPresent:[:aClass|
		(obj isKindOf: aClass) ifTrue: [
			obj method longPrintOn: stream indent: self indent + 2. ^ self]].