releaseCachedState
	"Release any state that can be recomputed on demand, such as the pixel values for a color gradient or the editor state for a TextMorph. This method may be called to save space when a morph becomes inaccessible. Implementations of this method should do 'super releaseCachedState'."
	self formerOwner: nil.
	self formerPosition: nil.
	self removeProperty: #undoGrabCommand.
	self wonderlandTexture: nil. "We can recreate it if needed"
	self borderStyle releaseCachedState.
