isEnabled
	enabled ifNil: [enabled := spec model perform: spec enabled].
	^ enabled