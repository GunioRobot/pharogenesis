destroyTexture: anExternalTexture
	"Destroy the given external form"
	self primDestroyTexture: anExternalTexture getExternalHandle.
	anExternalTexture setExternalHandle: nil on: nil.