update: aSelector
	| recognized |
	recognized := self eventAccessors collect: [:ea | spec perform: ea].
	(recognized includes: aSelector)
		ifTrue: [spec model perform: aSelector]