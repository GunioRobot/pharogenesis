getBg
	"Retrieve the current model background color/image"

	getBgSelector == nil ifTrue: [^Color white].
	^ (model perform: getBgSelector) ifNil: [Color white]
	
