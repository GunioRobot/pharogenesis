destroy
	"Destroy the receiver"
	renderer == nil ifFalse:[renderer destroyTexture: self].
	renderer _ nil.