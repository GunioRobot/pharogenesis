encoder
	encoder isNil ifTrue:
		[encoder := EncoderForV3PlusClosures new].
	^encoder