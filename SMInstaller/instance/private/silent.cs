silent
	"Can we ask questions?"
	
	^packageRelease ifNotNil: [packageRelease map silent] ifNil: [false]