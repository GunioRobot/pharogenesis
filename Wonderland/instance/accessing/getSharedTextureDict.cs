getSharedTextureDict
	"Return the shared texture dictionary"

	^ sharedTextureDict ifNil:[sharedTextureDict _ Dictionary new].