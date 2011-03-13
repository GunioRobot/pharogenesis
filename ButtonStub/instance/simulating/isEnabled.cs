isEnabled
	enabled ifNil: [enabled _ spec model perform: spec enabled].
	^ enabled