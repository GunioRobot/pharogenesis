uploadTexture: aTexture
	aTexture ifNil:[^nil].
	aTexture needsUpload ifFalse:[^self]. "no point"
	self primRender: handle uploadTexture: aTexture getExternalHandle from: aTexture.