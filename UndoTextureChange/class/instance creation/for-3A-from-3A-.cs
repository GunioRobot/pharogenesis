for: anActor from: oldTexture
	"Wrap an actor and its old texture so that we can undo the texture change"

	^ (self new) setActor: anActor andTexture: oldTexture.
