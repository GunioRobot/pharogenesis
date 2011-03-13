testOtherClasses

	#(WordArrayForSegment FloatArray PointArray IntegerArray SoundBuffer String ShortPointArray ShortIntegerArray WordArray Array DependentsArray   ByteArray Bitmap ColorArray ) do: [:s | | a |
		a := (Smalltalk at: s) new: 3.
		self assert: (a basicSize * a bytesPerBasicElement = a byteSize). ]
