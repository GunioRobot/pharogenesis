selectCodec

	| aMenu codecs newCodec |
	aMenu _ CustomMenu new title: 'Codec:'.
	codecs _ (SoundCodec allSubclasses collect: [:c | c name]) asSortedCollection.
	codecs add: 'None'.
	codecs do:[:cName | aMenu add: cName action: cName].
	newCodec _ aMenu startUp.
	newCodec ifNil: [^ self].
	self codecClassName: newCodec.
