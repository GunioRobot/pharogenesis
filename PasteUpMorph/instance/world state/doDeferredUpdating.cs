doDeferredUpdating
	"If this platform supports deferred updates, then make my canvas be the Display (or a rectangular portion of it), set the Display to deferred update mode, and answer true. Otherwise, do nothing and answer false. One can set the class variable DisableDeferredUpdates to true to completely disable the deferred updating feature."

	DisableDeferredUpdates ifNil: [DisableDeferredUpdates _ false].
	DisableDeferredUpdates ifTrue: [^ false].
	(Display deferUpdates: true) ifNil: [^ false].  "deferred updates not supported"

	self == World
		ifTrue: [  "this world fills the entire Display"
			((self canvas == nil) or: [self canvas form ~~ Display]) ifTrue: [
				self canvas: (Display getCanvas).
				self viewBox: Display boundingBox]]
		ifFalse: [  "this world is inside an MVC window"
			((self canvas == nil) or:
			 [(self canvas form ~~ Display) or:
			 [(self canvas origin ~= self viewBox origin)]]) ifTrue: [
				self canvas:
					((Display getCanvas)
						copyOffset: self viewBox origin clipRect: self viewBox)]].
	^ true
