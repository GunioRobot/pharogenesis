ensuredEngine
	engine ifNil:[
		true
			ifTrue:[engine _ BalloonEngine new]
			ifFalse:[engine _ BalloonDebugEngine new].
		engine aaLevel: aaLevel.
		engine bitBlt: port.
		engine destOffset: origin.
		engine clipRect: clipRect.
		engine deferred: deferred.
		engine].
	engine colorTransform: colorTransform.
	engine edgeTransform: transform.
	^engine