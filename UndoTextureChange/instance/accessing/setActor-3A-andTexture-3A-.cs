setActor: anActor andTexture: aTexture
	"Store the old texture and the actor to restore it to"

	theActor _ anActor.
	originalTexture _ aTexture.
