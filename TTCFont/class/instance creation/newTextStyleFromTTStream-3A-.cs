newTextStyleFromTTStream: readStream
"
"

	| description |
	description _ TTFontDescription addFromTTStream: readStream.
	^ self newTextStyleFromTT: description.
